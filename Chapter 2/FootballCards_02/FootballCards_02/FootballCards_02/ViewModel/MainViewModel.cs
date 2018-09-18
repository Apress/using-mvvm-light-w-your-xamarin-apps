using GalaSoft.MvvmLight;
using FootballCards_02.Model;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using System;

namespace FootballCards_02
{
    public class MainViewModel : ViewModelBase
    {
        List<Cards> FootballCards;
        RelayCommand buttonClicked;

        public MainViewModel()
        {
            // propogate the Football cards List
            FootballCards = Helpers.Helpers.GenerateCards;

            // give the number of shuffles a default
            NumberOfShuffles = 0;

            // fill the UI properties
            var firstTeam = FootballCards.First();

            TeamName = firstTeam.TeamName;
            StadiumName = firstTeam.StadiumName;
            Capacity = firstTeam.Capacity;
            Longitude = firstTeam.Longitude;
            Latitude = firstTeam.Latitude;
        }

        // number of shuffles
        int numberShuffles;
        public int NumberOfShuffles
        {
            get {
                return numberShuffles;
            }
            set {
                Set(() => NumberOfShuffles, ref numberShuffles, value, true);

                if (numberShuffles > 0) // enable the click
                    buttonClicked.RaiseCanExecuteChanged();
            }
        }

        string teamName;
        public string TeamName
        {
            get {
                return teamName;
            }
            set {
                Set(() => TeamName, ref teamName, value, true);
            }
        }

        string stadiumName;
        public string StadiumName
        {
            get {
                return stadiumName;
            }
            set {
                Set(() => StadiumName, ref stadiumName, value, true);
            }
        }

        int capacity;
        public int Capacity
        {
            get {
                return capacity;
            }
            set {
                Set(() => Capacity, ref capacity, value, true);
            }
        }

        double latitude;
        public double Latitude
        {
            get {
                return latitude;
            }
            set {
                Set(() => Latitude, ref latitude, value, true);
            }
        }

        double longitude;
        public double Longitude
        {
            get {
                return longitude;
            }
            set {
                Set(() => Longitude, ref longitude, value, true);
            }
        }

        string textNumber;
        public string TextNumberOfShuffles
        {
            get
            {
                return textNumber;
            }
            set
            {
                Set(() => TextNumberOfShuffles, ref textNumber, value);
                if (!string.IsNullOrEmpty(textNumber))
                    NumberOfShuffles = Convert.ToInt32(textNumber);
            }
        }

        // create the RelayCommand
        public RelayCommand ButtonClicked
        {
            get {
                return buttonClicked ??
                (buttonClicked = new RelayCommand(
                    () =>
                    {
                        // Shuffle the cards NumberOfShuffles times
                        FootballCards = Helpers.CardShuffle.Shuffle(FootballCards, NumberOfShuffles);

                        // get the first card
                        var topCard = FootballCards.First();

                        // propogate the properties
                        TeamName = topCard.TeamName;
                        StadiumName = topCard.StadiumName;
                        Capacity = topCard.Capacity;
                        Longitude = topCard.Longitude;
                        Latitude = topCard.Latitude;
                    }));
            }
        }
    }
}