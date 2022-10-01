/*Name: Zain & Henry
* Description: a card based memory game
* Input: clicks on cards
* Output: show if you have two matched cards
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        //setting const variable for total card number
        const int TOTAL_CARDS = 20;

        //declare card image array
        PictureBox[] cards = new PictureBox[TOTAL_CARDS];

        //declare card id array
        int[] cardId = new int[TOTAL_CARDS];

        //declare variable for picked cards as counter
        int cardsPicked = 0;

        //declare string variable for previous card id
        string prevCard;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //loop thru every card
            for (int i = 0; i < TOTAL_CARDS; i++)
            {
                //if the card index is smaller than 9, card number is smaller than 10
                if (i < 9)
                    //show image as card 0[the number]
                    cards[i] =
                        (PictureBox)
                        this.Controls["card0" + (i + 1).ToString()];
                else
                    //if the card index is other than 9, which is bigger or equal to 10
                    //show the card as just index + 1
                    cards[i] =
                        (PictureBox) this.Controls["card" + (i + 1).ToString()];

                //stretch image to look good
                cards[i].SizeMode = PictureBoxSizeMode.StretchImage;

                //call function clicked_on_card
                cards[i].Click += Clicked_On_Card;

                //write log to record gameplay history
                Console.WriteLine($"LOADED {i} ---  card {(i + 1).ToString()}");
            }
        }

        //function for start game button
        private void StartButton_Click(object sender, EventArgs e)
        {
            Random rand = new Random(); //setting new random seed

            //loop thru each card
            for (int i = 0; i < TOTAL_CARDS; i++)
            {
                //initiate image back color
                cards[i].Image = Properties.Resources.red_back;

                //initiate image id
                cardId[i] = i + 1;
            }

            //randomization loop, loop thru every possible outcome or every card
            //it was 20 for 4 cards in the vid now for 20 we multiply it by 5
            for (int i = 0; i < TOTAL_CARDS * 5; i++)
            {
                //doing random sorting and switching to make sure it is
                //very random indeed
                int
                    x = rand.Next(TOTAL_CARDS),
                    y = rand.Next(TOTAL_CARDS);
                int temp = cardId[x];
                cardId[x] = cardId[y];
                cardId[y] = temp;
            }
        }

        //function for clicking on cards
        private async void Clicked_On_Card(object sender, EventArgs e)
        {
            //if this is the first card you picked
            if (cardsPicked < 2)
            {
                //assign pitureClicked with the user's pick
                PictureBox pictureClicked = (PictureBox) sender;

                //card name set to pictureClick'name
                string name = pictureClicked.Name.ToString();

                cardsPicked++; //incrementing cards picked
                if (
                    cardsPicked == 1 //if you picked one card already
                ) prevCard = name; //previous card is set to name

                //assign index values to already picked cards
                int
                    index =
                        ((name[name.Length - 2] - '0') * 10) +
                        (name[name.Length - 1] - '0') -
                        1,
                    index2 =
                        ((prevCard[prevCard.Length - 2] - '0') * 10) +
                        (prevCard[prevCard.Length - 1] - '0') -
                        1;

                //call getCardById function to get the image of the card
                cards[index].Image = getCardById(cardId[index]);

                if (
                    cardsPicked == 2 //if this is the second card
                )
                {
                    await Task.Delay(2000); //wait for 2 seconds delay

                    //if two cards are the same
                    if (
                        getCardById(cardId[index]).Tag ==
                        getCardById(cardId[index2]).Tag
                    )
                        //make them disappear
                        cards[index].Visible = cards[index2].Visible = false; //if two cards are different
                    else
                        //show their back again
                        cards[index].Image =
                            cards[index2].Image = Properties.Resources.red_back;

                    cardsPicked = 0; //reset picked card counter to 0;
                }
            }
        }

        //function that get card image by its id
        private Image getCardById(int id)
        {
            Image img = null; //initiate images as null

            //use switch statements to give different images based on ids
            switch (id)
            {
                case 1:
                    img = Properties.Resources.AC;
                    img.Tag = "AC";
                    break;
                case 2:
                    img = Properties.Resources.AD;
                    img.Tag = "AD";
                    break;
                case 3:
                    img = Properties.Resources.AH;
                    img.Tag = "AH";
                    break;
                case 4:
                    img = Properties.Resources.AS;
                    img.Tag = "AS";
                    break;
                case 5:
                    img = Properties.Resources.JC;
                    img.Tag = "JC";
                    break;
                case 6:
                    img = Properties.Resources.JD;
                    img.Tag = "JD";
                    break;
                case 7:
                    img = Properties.Resources.JH;
                    img.Tag = "JH";
                    break;
                case 8:
                    img = Properties.Resources.JS;
                    img.Tag = "JS";
                    break;
                case 9:
                    img = Properties.Resources.KC;
                    img.Tag = "KC";
                    break;
                case 10:
                    img = Properties.Resources.KD;
                    img.Tag = "KD";
                    break;
                case 11:
                    img = Properties.Resources.AC;
                    img.Tag = "AC";
                    break;
                case 12:
                    img = Properties.Resources.AD;
                    img.Tag = "AD";
                    break;
                case 13:
                    img = Properties.Resources.AH;
                    img.Tag = "AH";
                    break;
                case 14:
                    img = Properties.Resources.AS;
                    img.Tag = "AS";
                    break;
                case 15:
                    img = Properties.Resources.JC;
                    img.Tag = "JC";
                    break;
                case 16:
                    img = Properties.Resources.JD;
                    img.Tag = "JD";
                    break;
                case 17:
                    img = Properties.Resources.JH;
                    img.Tag = "JH";
                    break;
                case 18:
                    img = Properties.Resources.JS;
                    img.Tag = "JS";
                    break;
                case 19:
                    img = Properties.Resources.KC;
                    img.Tag = "KC";
                    break;
                case 20:
                    img = Properties.Resources.KD;
                    img.Tag = "KD";
                    break;
            }
            return img; //return the image in the end to give image
        }
    }
}
