using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using SpotifyAPI.Local;
using SpotifyAPI.Local.Enums;
using SpotifyAPI.Local.Models;

using System.Windows;

namespace AppleWirelessKeyboard
{
    public static class SpotifyControl
    {
        public static bool SpotifyRunning
        {
            get
            {
                var processes = Process.GetProcesses();
                return Process.GetProcessesByName("Spotify").Any();
            }
        }
        public static void NextSong()
        {
            SpotifyLocalAPI _spotify = new SpotifyLocalAPI();
            if (!_spotify.Connect())
            {
                return;
            }
            _spotify.Skip();
            _spotify = null;
        }
        public static void PreviousSong()
        {
            SpotifyLocalAPI _spotify = new SpotifyLocalAPI();
            if (!_spotify.Connect())
            {
                return;
            }
            _spotify.Previous();
            _spotify = null;
        }
        public static void PlayPause()
        {
            SpotifyLocalAPI _spotify = new SpotifyLocalAPI();
            if (!_spotify.Connect())
            {
                return;
            }
            StatusResponse status = _spotify.GetStatus();
            if (status == null)
            {
                return;
            }

            if (status.Playing)
            {
                _spotify.Pause();
            }
            else
            {
                _spotify.Play();
            }

            _spotify = null;
        }
    }
}