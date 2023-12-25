using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    public class bank_account
    {
        static private List<bank_account> accs = new List<bank_account>();
        private int number;
        private string fio;
        private float sum;
        private int accs_counter = 0;
        private int selected_accs;
        private float money;
        private int i;

        public bank_account(string fio, float sum)
        {
            this.fio = fio;
            this.sum = sum;
            accs.Add(this);
        }
        private float get_money(int index)
        {
            return accs[index - 1].sum;
        }
        private int selected_acc(int num)
        {
            selected_accs = num;
            return selected_accs;
        }
        private void Out()
        {
            Console.WriteLine("Name of owner: " + fio + "\n money on acc: " + sum);
        }
        private void dob(float sum)
        {
            this.sum += sum;
        }
        private void umen(float sum)
        {
            this.sum -= sum;
        }
        private void obnul()
        {
            sum = 0;
        }
        private void transfer_money(int from_who, int to_who, float sum)
        {
            accs[from_who].sum -= sum;
            accs[to_who].sum += sum;
        }
        public void input()
        {
            try
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("menu\n C - to create new acc \n P to choose some acc \n I - to bring out info \n D - to replenish bank_acc \n U - to withdraw money \n N - to withdraw all money \n T - to transfer some money to some acc");
                    ConsoleKey need_key = Console.ReadKey().Key;
                    Console.WriteLine();

                    switch (need_key)
                    {

                        case ConsoleKey.C:
                            Console.WriteLine("Enter owner's name: ");
                            string fio = Console.ReadLine();
                            Console.WriteLine("Enter money on acc: ");
                            money = float.Parse(Console.ReadLine());
                            i++;
                            new bank_account(fio, money);
                            Console.WriteLine("You create acc and need to enter some acc");
                            Console.WriteLine("Press any key to continue: ");
                            Console.ReadKey();
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("Enter which account you want to choose. ");
                                Console.WriteLine("You have: " + accs.Count + " accs");
                            int num = int.Parse(Console.ReadLine());
                            if ((num > accs.Count) || (num <= 0))
                            {
                                Console.WriteLine("You doesn't have this acc, only: " + accs.Count);
                                Console.ReadKey();
                                break;
                            }
                            selected_accs = num;
                            break;
                        case ConsoleKey.I:
                            accs[selected_accs - 1].Out();
                            Console.WriteLine("Press any key to continue: ");
                            Console.ReadKey();
                            break;
                        case ConsoleKey.D:
                            Console.WriteLine("Enter the amount of money to top up");
                            float dep = float.Parse(Console.ReadLine());
                            money += dep;
                            accs[selected_accs - 1].dob(dep);
                            break;
                        case ConsoleKey.U:
                            Console.WriteLine("Enter the amount of money to withdraw");
                            float ne_dep = float.Parse(Console.ReadLine());
                            if (ne_dep > money)
                            {
                                Console.WriteLine("You doesn't have " + ne_dep + " only" + money);
                                Console.ReadKey();
                                break;
                            }
                            money -= ne_dep;
                            accs[selected_accs - 1].umen(ne_dep);
                            break;
                        case ConsoleKey.N:
                            money = 0;
                            accs[selected_accs - 1].obnul();
                            break;
                        case ConsoleKey.T:
                            Console.WriteLine("Enter to which account: ");
                            int second_acc = int.Parse(Console.ReadLine());
                            if ((accs.Count == 1) || (accs.Count == 0))
                            {
                                Console.WriteLine("You doesn't have accs for transfer");
                                Console.ReadKey();
                                break;
                            }
                            Console.WriteLine("Enter need money: ");
                            float money_to_trans = float.Parse(Console.ReadLine());
                            if (money_to_trans > accs[selected_accs - 1].get_money(selected_accs))
                            {
                                Console.WriteLine("You doesn't have money to transfer");
                                Console.ReadKey();
                                break;
                            }
                            accs[selected_accs - 1].transfer_money(selected_accs - 1, second_acc - 1, money_to_trans);
                            break;
                    }
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Something wrong");
                Console.ReadLine();
            }
        }
    }

}

