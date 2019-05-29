using IndependentProject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace IndependentProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Play : Page
    {
        private ObservableCollection<Card> Cards;

        public Play()
        {
            this.InitializeComponent();
        }
        // This is the number of pairs of cards in total. 
        private int PairNumber;
        // This is the number of cards which the user can choose on each turn. 
        private int ChooseNumber;
        private bool[] chosenArr;
        private int chosenNum;
        // This is whether or not we are selecting cards (as compared to looking at their values)
        private bool Selecting;

        private BipGraph G;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            PairNumber = ((int[])e.Parameter)[0];
            ChooseNumber = ((int[])e.Parameter)[1];
            Cards = CardManager.GetCards(PairNumber);
            chosenArr = new bool[PairNumber * 2];
            chosenNum = 0;
            // G is the graph connecting each card to their possible values
            // The two cards representing i are the numbers i and PairNumber + i, for organization
            G = new BipGraph(2 * PairNumber, 2 * PairNumber);
            ConfirmButton.Visibility = Visibility.Collapsed;
            ShuffleButton.Visibility = Visibility.Collapsed;
            WinBlock.Visibility = Visibility.Collapsed;
            for (int i = 1; i <= 2*PairNumber; i++)
            {
                for (int j = 1; j <= 2 * PairNumber; j++)
                {
                    G.AddEdge(i, j);
                }
            }
            Selecting = true;
        }

        private void GridView_Click(object sender, ItemClickEventArgs e)
        {
            // Clicking the cards should only change stuff if the user is supposed to be clicking them
            if (Selecting)
            {
                Card output = e.ClickedItem as Card;
                if (chosenArr[output.Id])
                {
                    // If already chosen, deselect the card
                    chosenArr[output.Id] = false;
                    chosenNum--;
                    Cards[output.Id].Border = new SolidColorBrush(Windows.UI.Colors.White);
                }
                else
                {
                    chosenArr[output.Id] = true;
                    chosenNum++;
                    Cards[output.Id].Border = new SolidColorBrush(Windows.UI.Colors.Black);
                }
                // ConfirmButton should only be visible if there are exactly ChooseNumber cards selected
                if (chosenNum == ChooseNumber)
                {
                    ConfirmButton.Visibility = Visibility.Visible;
                }
                else
                {
                    ConfirmButton.Visibility = Visibility.Collapsed;
                }
                TestBlock.Text = ("Cards chosen: " + chosenNum.ToString());
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            TestBlock.Text = "Cards chosen: 0";
            Selecting = false;
            ConfirmButton.Visibility = Visibility.Collapsed;
            // This is the temporary bipartite graph, connecting the chosen cards to the possible values they can be
            // We ignore the cards which were not chosen, so they will not have connections and will not affect the algorithm
            BipGraph GTemp = new BipGraph(2 * PairNumber, PairNumber);
            for (int i = 0; i < 2 * PairNumber; i++)
            {
                if (chosenArr[i])
                {
                    // For each vertex adjacent to i in G, add a connection in GTemp
                    foreach (int adj in G.adj[i + 1])
                    {
                        GTemp.AddEdge(i + 1, (adj - 1) % PairNumber + 1);
                    }
                }
            }
            int[] adjChosen = GTemp.HopcroftKarp();
            // Check if all chosen cards can have a unique value.
            // If they can, we are basically done. Otherwise, we need to do another Hopcroft Karp, this time where duplicate values are allowed
            bool valid = true;
            for (int i = 0; i < 2 * PairNumber; i++)
            {
                if (chosenArr[i])
                {
                    // Adding 1 for 1-based indices
                    if (adjChosen[i + 1] == 0)
                    {
                        valid = false;
                        break;
                    }
                }
            }
            if (valid)
            {
                // Set and store the values chosen to the cards
                HashSet<int> values = new HashSet<int>();
                for (int i = 0; i < 2 * PairNumber; i++)
                {
                    if (chosenArr[i])
                    {
                        if (G.hasEdge(i + 1, adjChosen[i + 1]))
                        {
                            values.Add(adjChosen[i + 1]);
                        } else
                        {
                            values.Add(adjChosen[i + 1] + PairNumber);
                        }
                        Cards[i].Text = (adjChosen[i + 1].ToString());
                    }
                }
                for (int i = 0; i < 2 * PairNumber; i++)
                {
                    if (chosenArr[i])
                    {
                        G.ClearVertex(i + 1);
                        foreach (int j in values)
                        {
                            G.AddEdge(i + 1, j);
                        }
                    }
                }
                // We cannot let non-chosen cards take on the value of a chosen card
                for (int i = 0; i < 2 * PairNumber; i++)
                {
                    if (!chosenArr[i])
                    {
                        foreach (int j in values)
                        {
                            G.ClearEdge(i + 1, j);
                        }
                    }
                }
                // We are allowed to shuffle now, as the game is still going on
                ShuffleButton.Visibility = Visibility.Visible;
                return;
            }
            // If we are here, we know that it wasn't valid, so we know that we lost
            // We decide the values of the cards using Hopcroft-Karp again on the graph counting duplicates
            // Using a different BipGraph because the number of possible values of cards is now different
            BipGraph GTemp2 = new BipGraph(2 * PairNumber, 2 * PairNumber);
            for (int i = 0; i < 2 * PairNumber; i++)
            {
                if (chosenArr[i])
                {
                    // For each vertex adjacent to i in G, add a connection in GTemp
                    foreach (int adj in G.adj[i + 1])
                    {
                        GTemp2.AddEdge(i + 1, adj);
                    }
                }
            }
            int[] adjChosen2 = GTemp2.HopcroftKarp();
            // We know the user won, so we don't have to shuffle cards anymore
            for (int i = 0; i < 2 * PairNumber; i++)
            {
                if (chosenArr[i])
                {
                    Cards[i].Text = ((adjChosen2[i + 1] - 1) % PairNumber + 1).ToString();
                }
            }
            WinBlock.Visibility = Visibility.Visible;
        }

        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset everything to before we selected anything. Do not reset the graph (G)
            ShuffleButton.Visibility = Visibility.Collapsed;
            Selecting = true;
            for (int i = 0; i < 2 * PairNumber; i++)
            {
                Cards[i].Text = "Card";
                Cards[i].Border = new SolidColorBrush(Windows.UI.Colors.White);
                if (chosenArr[i])
                {
                    Cards[i].Background = new SolidColorBrush(Windows.UI.Colors.LightSteelBlue);
                } else
                {
                    Cards[i].Background = new SolidColorBrush(Windows.UI.Colors.LightBlue);
                }
                chosenArr[i] = false;
            }
            chosenNum = 0;
        }
    }
}
