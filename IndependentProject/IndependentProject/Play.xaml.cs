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
            WinBlock.Visibility = Visibility.Collapsed;
            for (int i = 1; i <= 2*PairNumber; i++)
            {
                for (int j = 1; j <= 2 * PairNumber; j++)
                {
                    G.addEdge(i, j);
                }
            }
        }

        private void GridView_Click(object sender, ItemClickEventArgs e)
        {
            Card output = e.ClickedItem as Card;
            if (chosenArr[output.Id])
            {
                // If already chosen, deselect the card
                chosenArr[output.Id] = false;
                chosenNum--;
                Cards[output.Id].Border = new SolidColorBrush(Windows.UI.Colors.White);
            } else
            {
                chosenArr[output.Id] = true;
                chosenNum++;
                Cards[output.Id].Border = new SolidColorBrush(Windows.UI.Colors.Black);
            }
            // ConfirmButton should only be visible if there are exactly ChooseNumber cards selected
            if (chosenNum == ChooseNumber)
            {
                ConfirmButton.Visibility = Visibility.Visible;
            } else
            {
                ConfirmButton.Visibility = Visibility.Collapsed;
            }
            TestBlock.Text = chosenNum.ToString();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            // This is the temporary bipartite graph, connecting the chosen cards to the possible values they can be
            // We ignore the cards which were not chosen, so they will not have connections and will not affect the algorithm
            BipGraph GTemp = new BipGraph(2 * PairNumber, PairNumber);
            for (int i = 0; i < 2 * PairNumber; i++)
            {
                if (chosenArr[i])
                {
                    // For each vertex adjacent to i in G, add a connection in GTemp
                    foreach (int adj in G.adj[i])
                    {
                        GTemp.addEdge(i, (adj - 1) % PairNumber + 1);
                    }
                }
            }
            int[] adjChosen = GTemp.HopcroftKarp();
            // Check if all chosen cards can have a unique value.
            // If they can, we are basically done. Otherwise, we need to do another Hopcroft Karp, this time where duplicate values are allowed
            bool valid = true;
            TestBlock.Text = "";
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
                TestBlock.Text = (TestBlock.Text + (adjChosen[i + 1].ToString() + " "));
            }
            if (valid)
            {
                // Set and store the values chosen to the cards
                HashSet<int> values = new HashSet<int>();
                for (int i = 0; i <= 2 * PairNumber; i++)
                {
                    if (chosenArr[i])
                    {
                        if (G.hasEdge(i + 1, adjChosen[i + 1]))
                        {
                            values.Add(adjChosen[i + 1]);
                            Cards[i].Text = adjChosen[i + 1].ToString();
                        } else
                        {
                            values.Add(adjChosen[i + 1] + PairNumber);
                            Cards[i].Text = (adjChosen[i + 1] + PairNumber).ToString();
                        }
                    }
                }
                for (int i = 0; i <= 2 * PairNumber; i++)
                {
                    if (chosenArr[i])
                    {
                        G.clearEdge(i);
                        foreach (int j in values)
                        {
                            G.addEdge(i, j);
                        }
                    }
                }
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
                    foreach (int adj in G.adj[i])
                    {
                        GTemp2.addEdge(i, adj);
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
    }
}
