using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hortifruti.Models;

namespace Hortifruti.Menus
{
    public class AtualizarEntidade
    {
        public static (Cliente, int) AtualizarCliente(){

            string nome;
            string cpf;
            string telefone;
            int id;

            while (true)
            {
                Console.WriteLine("Digite o id:");
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nID inválido. Por favor, digite um número inteiro.\n");
                }
            }

            while(true)
            {
                Console.WriteLine("Digite o novo Nome:");
                nome = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nome))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Nome não pode ser vazio. Por favor, digite um Nome válido.");
                }
            }

            while(true)
            {
                Console.WriteLine("Digite o novo CPF:");
                cpf = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(cpf))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("CPF não pode ser vazio. Por favor, digite um CPF válido.");
                }
            }

            while(true)
            {
                Console.WriteLine("Digite o novo Telefone:");
                telefone = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(telefone))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Telefone não pode ser vazio. Por favor, digite um telefone válido.");
                }
            }

            
            Cliente cliente = new(nome, cpf, telefone);
            return (cliente, id);
        }
    }
}