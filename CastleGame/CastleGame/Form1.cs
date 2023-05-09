using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CastleGame
{
    public partial class Form1 : Form
    {
        private Castle castle1;
        private Castle castle2;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Получаем данные для первого замка
            int castle1Money = int.Parse(txtCastle1Money.Text);
            int castle1Income = int.Parse(txtCastle1Income.Text);
            int castle1Expenses = int.Parse(txtCastle1Expenses.Text);

            // Получаем данные для второго замка
            int castle2Money = int.Parse(txtCastle2Money.Text);
            int castle2Income = int.Parse(txtCastle2Income.Text);
            int castle2Expenses = int.Parse(txtCastle2Expenses.Text);

            // Создаем два замка
            castle1 = new Castle(txtCastle1Name.Text, castle1Money, castle1Income, castle1Expenses);
            castle2 = new Castle(txtCastle2Name.Text, castle2Money, castle2Income, castle2Expenses);

            // Отображаем начальные данные для замков
            ShowCastlesData();
        }

        private void btnSwitchDay_Click(object sender, EventArgs e)
        {
            // Переключаем день для обоих замков
            castle1.SwitchDay();
            castle2.SwitchDay();

            // Отображаем измененные данные для замков
            ShowCastlesData();
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            // Выбираем случайный замок для атаки
            Castle attackingCastle = GetAttackingCastle();

            // Получаем награбленную сумму
            int stolenMoney = attackingCastle.RobCastle();

            // Добавляем награбленную сумму к другому замку
            if (attackingCastle == castle1)
            {
                castle2.AddMoney(stolenMoney);
            }
            else
            {
                castle1.AddMoney(stolenMoney);
            }

            // Отображаем сообщение о грабеже
            string message = $"{attackingCastle.Name} ограблен на {stolenMoney} денег.";
            MessageBox.Show(message);

            // Отображаем измененные данные для замков
            ShowCastlesData();
        }

        private Castle GetAttackingCastle()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 2);

            if (randomNumber == 0)
            {
                return castle1;
            }
            else
            {
                return castle2;
            }
        }

        private void ShowCastlesData()
        {
            lblCastle1Money.Text = $"Деньги: {castle1.Money}";
            lblCastle2Money.Text = $"Деньги: {castle2.Money}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtCastle1Name_TextChanged(object sender, EventArgs e)
        {

        }
    }
}