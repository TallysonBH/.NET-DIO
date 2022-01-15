using System;


namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            var alunos = new Aluno[5];
             var IndiceAluno=0;

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do Aluno");
                        var aluno=new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do Aluno");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;

                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }

                        alunos[IndiceAluno] = aluno;
                        IndiceAluno++;


                        break;

                    case "2":
                        foreach(var a in alunos)
                        {   
                            if(!string.IsNullOrEmpty(a.Nome))
                            {
                            Console.WriteLine($"Aluno: {a.Nome} - NOTA: {a.Nota}");
                            }
                        }

                        
                        break;

                    case "3":
                    decimal NotaTotal=0;
                    var nrAlunos = 0;


                        for(int i=0 ; i<alunos.Length;i++)
                        {
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                NotaTotal = NotaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }


                        }

                        var mediaGeral = NotaTotal/nrAlunos;
                        Conceito conceitoGeral;

                        if(mediaGeral<2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if(mediaGeral<4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if(mediaGeral<6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if(mediaGeral<8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"Média GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");

                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }



        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opcao desejada");
            Console.WriteLine("1- Inserir Aluno.");
            Console.WriteLine("2- Listar Alunos.");
            Console.WriteLine("3- Calcular media geral.");
            Console.WriteLine("x- Sair.");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}


