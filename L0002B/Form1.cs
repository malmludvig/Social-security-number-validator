using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace L0002B
{
    public class Person
    {
        public string firstName;
        public string lastName;
        public string personNumber;
    }

    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Här skapar jag ett objekt från min klass.
            Person formPerson = new Person();

            formPerson.firstName = (textBox1.Text);
            formPerson.lastName = (textBox2.Text);
            formPerson.personNumber = (textBox4.Text);

            textBox3.Text = "\r\nFörnamn: " + formPerson.firstName + "\r\nEfternamn: " + formPerson.lastName + "\r\nPersonnummer: ";

            long personNumber = Convert.ToInt64(formPerson.personNumber);
            long lastNumber = Convert.ToInt64(formPerson.personNumber);

            //Kontrollsiffran har jag valt som algoritm för att kontrollera personnumret. 

            //Den här metoden tar ett invärde av typen long, och skapar en lista med mina siffror i separata element.
            //Jag behöver göra detta för att kunna bearbeta varje siffra var för sig när jag ska ta reda på kontrolltalet.
            long[] CreateListFromInt(long data)
            {
                List<long> listOfInts = new List<long>();
                while (data > 0)
                {
                    listOfInts.Add(data % 10);
                    data = data / 10;
                }
                listOfInts.Reverse();
                return listOfInts.ToArray();
            }

            //Det här heltalet ser helt enkelt till så att varannan iteration av min senare foreach-loop sker annorlunda.
            int alternator = 2;

            //Den här listan kommer jag att populera med alla siffror från mitt personnummer.
            List<long> listOfSifferSumma = new List<long>();

            //Jag skapar en int som håller koll på vilken siffra som jag kör igenom med min foreach med, och när jag är på näst sista platsen på personnumret så lagrar jag den siffran.
            int foreachCounter = 1;

            //Loopar igenom min lista över mina siffror i mitt personnummer och växelvis multiplicerar dem med 2 eller 1.
            foreach (var x in CreateListFromInt(personNumber))

            {
                if (foreachCounter == 9)
                {
                    lastNumber = x;
                }

                if (alternator % 2 == 0)
                {
                    listOfSifferSumma.Add(x * 2);
                    alternator++;
                }
                else
                {
                    listOfSifferSumma.Add(x * 1);
                    alternator++;
                }

                foreachCounter++;
            }

            int sifferSumma = 0;

            //Här har jag ett häftigt lambda-uttryck som använder LINQ som omvandlar hela min List<long> till List<int>.
            List<int> listOfSifferSummaButInt = listOfSifferSumma.Select(i => (int)i).ToList();

            foreach (var x in listOfSifferSummaButInt)

            {
                //Den här if-satsen ser till att man räknar tiotal (allt mellan 10 och 20) som två separata tal. Till exempel så blir 18 istället 1 + 8.

                if (x == 10)
                {
                    sifferSumma = sifferSumma + 1;
                }
                else if (x > 10)
                {
                    sifferSumma = sifferSumma + x - 10 + 1;
                }
                else
                {
                    sifferSumma = sifferSumma + x;
                }
            }

            CheckGender(formPerson, lastNumber, sifferSumma);
        }

        private void CheckGender(Person formPerson, long lastNumber, int sifferSumma)
        {           
            //Jag skapar en double, så att jag kan dubbelkolla så att min kontrollsiffra är jämnt delbar med tio, och inte får några decimaler.
            double sifferSummaMedDecimaler = sifferSumma;

            //Om den näst sista siffran i personnumret är jämn så är det en kvinna, annars en man.
            if (sifferSummaMedDecimaler % 10 == 0)
            {
                if (lastNumber % 2 == 0)
                {
                    textBox3.Text = textBox3.Text + formPerson.personNumber + "\r\nKön: Kvinna";
                }
                else
                {
                    textBox3.Text = textBox3.Text + formPerson.personNumber + "\r\nKön: Man";
                }
            }
            else
            {
                textBox3.Text = textBox3.Text + formPerson.personNumber + "\r\nDu har skrivit in ett icke korrekt personnummer.\r\n";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

            private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}