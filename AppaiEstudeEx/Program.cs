using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appai.Domain;
using Appai.Service;
using Microsoft.AspNetCore.Hosting;

namespace AppaiEstudeEx
{
    public class Program
    {
        static void Main(string[] args)
        {
            PrintMenu menu = new PrintMenu();
            AlunoService alunoService = new AlunoService();
            ProfessorService professorService = new ProfessorService();
            MateriaService materiaService = new MateriaService();


            
            menu.MenuPrincipal();


            do
            {


                switch (Console.ReadLine())
                {

                    case "0":
                        Environment.Exit(0);

                        break;


                    case "1":

                        menu.MenuAluno();

                        switch (Console.ReadLine())
                        {


                            case "1":
                                {

                                    List<Aluno> alunos = alunoService.getAlunos();


                                    for (int i = 0; i < alunos.Count; i++)
                                    {
                                        List<Materia> materias = alunos[i].Materia;

                                        Console.WriteLine("Nome: " + alunos[i].Nome + " " + "Email: " + alunos[i].Email + " " + "Id:" + alunos[i].Id);
                                        for (int j = 0; j < materias.Count; j++)
                                        {
                                            Console.WriteLine("Materia: " + materias[j].Nome + " Nota:" + materias[j].Nota);
                                        }
                                        Console.WriteLine("Status do Aluno: " + alunos[i].Status);
                                    }

                                    Console.WriteLine("Aperte Enter para sair.");

                                    Console.ReadLine();



                                    Console.Clear();

                                    menu.MenuAluno();

                                    break;
                                }
                            case "2":
                                {


                                    string opcao = "1";

                                    while (opcao == "1")
                                    {



                                        Console.Write("Nome: ");
                                        string nome = Console.ReadLine();

                                        Console.Write("Email: ");
                                        string email = Console.ReadLine();


                                        if (alunoService.Cadastrar(nome, email))
                                        {
                                            Console.WriteLine("Aluno Cadastrado com sucesso");
                                            Console.ReadLine();
                                            Console.Clear();

                                        }
                                        else
                                        {
                                            Console.WriteLine("Aluno com o email " + email + " já cadastrado!");
                                            Console.ReadLine();
                                        }
                                        Console.WriteLine("Deseja inserir outro dado? 1-SIM | 2-NÃO");
                                        opcao = Console.ReadLine();
                                        Console.Clear();
                                    }



                                    menu.MenuAluno();

                                    break;
                                }
                            case "3":
                                {
                                    string opcao = "1";
                                    while (opcao == "1")
                                    {
                                        Console.WriteLine("Digite o ID do Aluno e aperte Enter");
                                        int idAlun = int.Parse(Console.ReadLine());


                                        bool alunoP = alunoService.localizarP(idAlun);

                                        if (alunoP == false)
                                        {
                                            Console.WriteLine("aluno com o ID: " + idAlun + " não encontrado.");
                                            Console.WriteLine("deseja verificar outro Aluno? 1-SIM | 2-NÃO");
                                            opcao = Console.ReadLine();

                                        }
                                        else
                                        {


                                            Console.WriteLine("Deseja Cadastrar uma Materia ao Aluno: ? 1-SIM | 2-NÃO");

                                            opcao = Console.ReadLine();
                                            if (opcao == "1")
                                            {
                                                List<Materia> materia = materiaService.GetMaterias();

                                                materia.ForEach(materias => Console.WriteLine("Materia: " + materias.Nome + " Id: " + materias.Id));
                                                Console.WriteLine("Digite o ID da Materia para cadastrar no aluno");
                                                int idMat = int.Parse(Console.ReadLine());


                                                bool mate = materiaService.Localizar(idMat);
                                                if (mate == false)
                                                {
                                                    Console.WriteLine("Materia com o ID: " + idMat + " não encontrado.");
                                                    Console.WriteLine("deseja tentar novamente 1-SIM | 2-NÃO");
                                                    opcao = Console.ReadLine();

                                                }
                                                else
                                                {
                                                    bool matLoc = alunoService.MateriaVerifica(idAlun, idMat);
                                                    if (matLoc == true)
                                                    {
                                                        Console.WriteLine("Aluno já se encontra Com a Materia");
                                                        Console.WriteLine("deseja verificar outro aluno? 1-SIM | 2-NÃO");
                                                        opcao = Console.ReadLine();
                                                    }
                                                    else
                                                    {

                                                        alunoService.CadastrarMateria(idAlun, idMat);

                                                        Console.WriteLine("Materia cadastrada ao aluno com sucesso!");

                                                    }

                                                    Console.WriteLine("Aperte enter para sair");
                                                    Console.ReadLine();
                                                    Console.Clear();
                                                }
                                            }



                                        }
                                        if (opcao == "1")
                                        {
                                            Console.WriteLine("deseja Cadastrar outro aluno? 1-SIM | 2-NÃO");
                                            opcao = Console.ReadLine();
                                        }

                                    }


                                    Console.Clear();
                                    menu.MenuAluno();

                                    break;
                                }
                            case "4":
                                {

                                    string opcao = "1";
                                    while (opcao == "1")
                                    {
                                        Console.WriteLine("Digite o ID do Aluno e aperte Enter");
                                        int idAlun = int.Parse(Console.ReadLine());

                                        bool aluno = alunoService.localizarP(idAlun);

                                        if (aluno == false)
                                        {
                                            Console.WriteLine("aluno com o ID: " + idAlun + " não encontrado.");
                                            Console.WriteLine("deseja verificar outro Aluno? 1-SIM | 2-NÃO");
                                            opcao = Console.ReadLine();

                                        }
                                        else
                                        {


                                            Console.WriteLine("Deseja Cadastrar uma nota para a  Materia do Aluno:? 1-SIM | 2-NÃO");

                                            opcao = Console.ReadLine();
                                            if (opcao == "1")
                                            {

                                                Aluno alunos = alunoService.LocalizarAluno1(idAlun);

                                                alunos.Materia.ForEach(materias => Console.WriteLine("Materia: " + materias.Nome + " Id: " + materias.Id));
                                                Console.WriteLine("Digite o ID da Materia cadastrada no aluno");


                                                int idMat = int.Parse(Console.ReadLine());

                                                bool mate = materiaService.Localizar(idMat);
                                                if (mate == false)
                                                {
                                                    Console.WriteLine("Materia com o ID: " + idMat + " não encontrado.");
                                                    Console.WriteLine("deseja tentar novamente 1-SIM | 2-NÃO");
                                                    opcao = Console.ReadLine();

                                                }
                                                else
                                                {
                                                    Console.WriteLine("Digite a nota da materia escolhida: ");
                                                    double nota = double.Parse(Console.ReadLine());

                                                    alunoService.CadastrarNota(idAlun, idMat, nota);

                                                    Console.WriteLine("Nota cadastrada na Materia do aluno com sucesso!");


                                                    Console.WriteLine("Aperte enter para sair");
                                                    Console.ReadLine();
                                                    Console.Clear();
                                                }
                                            }



                                        }
                                        if (opcao == "1")
                                        {
                                            Console.WriteLine("deseja Cadastrar outro aluno? 1-SIM | 2-NÃO");
                                            opcao = Console.ReadLine();
                                        }

                                    }


                                    Console.Clear();
                                    menu.MenuAluno();


                                    break;
                                }
                            case "5":

                                string opcao2 = "1";



                                while (opcao2 == "1")
                                {
                                    Console.WriteLine("Digite o ID que deseja apagar e aperte Enter");

                                    int id = int.Parse(Console.ReadLine());



                                    if (alunoService.Remover(id))
                                    {
                                        Console.WriteLine("Aluno removido com sucesso!");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Aluno com o id: " + id + " Não encontrado!");
                                        Console.ReadLine();

                                    }

                                    Console.Clear();
                                    Console.WriteLine("Deseja remover outro ID?  1-SIM | 2-NÃO");
                                    opcao2 = Console.ReadLine();

                                }
                                menu.MenuAluno();
                                break;

                            case "6":

                                Console.Clear();
                                menu.MenuPrincipal();


                                break;
                            default:

                                Console.WriteLine("Digite uma opção valida");
                                Console.WriteLine("Aperte Enter para continuar");
                                Console.ReadLine();
                                Console.Clear();
                                menu.MenuAluno();
                                break;

                        }


                        Console.Clear();

                        menu.MenuPrincipal();
                        break;

                    case "2":

                        menu.MenuProfessor();

                        switch (Console.ReadLine())
                        {


                            case "1":
                                {

                                    List<Professor> professor = professorService.getProfessor();


                                    for (int i = 0; i < professor.Count; i++)
                                    {
                                        Materia materias = professor[i].Materia;

                                        Console.WriteLine("Nome: " + professor[i].Nome + " " + "Email: " + professor[i].Email + " " + "Id:" + professor[i].Id);
                                        if (materias != null)
                                        {

                                            Console.WriteLine("Materia: " + materias.Nome);
                                        }
                                        Console.WriteLine("Status do Professor: " + professor[i].Status);


                                    }
                                    Console.WriteLine("Aperte Enter para sair.");

                                    Console.ReadLine();

                                    Console.Clear();

                                    menu.MenuPrincipal();


                                    break;
                                }
                            case "2":
                                {
                                    string opcao = "1";

                                    while (opcao == "1")
                                    {



                                        Console.Write("Nome: ");
                                        string nome = Console.ReadLine();

                                        Console.Write("Email: ");
                                        string email = Console.ReadLine();


                                        if (professorService.Cadastrar(nome, email))
                                        {
                                            Console.WriteLine("Professor Cadastrado com sucesso");
                                            Console.ReadLine();
                                            Console.Clear();

                                        }
                                        else
                                        {
                                            Console.WriteLine("Professor com o email " + email + " já cadastrado!");
                                            Console.ReadLine();
                                        }
                                        Console.WriteLine("Deseja inserir outro dado? 1-SIM | 2-NÃO");
                                        opcao = Console.ReadLine();
                                        Console.Clear();
                                    }

                                    Console.Clear();

                                    menu.MenuPrincipal();



                                    break;
                                }
                            case "3":
                                {
                                    string opcao = "1";
                                    while (opcao == "1")
                                    {
                                        Console.WriteLine("Digite o ID do Professor e aperte Enter");
                                        int idProf = int.Parse(Console.ReadLine());


                                        bool professor = professorService.localizarP(idProf);
                                        bool professorM = professorService.MateriaVerifica(idProf);

                                        if (professor == false)
                                        {
                                            Console.WriteLine("Professor com o ID: " + idProf + " não encontrado.");
                                            Console.WriteLine("deseja verificar outro Professor? 1-SIM | 2-NÃO");
                                            opcao = Console.ReadLine();
                                        }
                                        else
                                        {
                                            if (professorM == false)
                                            {
                                                Console.WriteLine("Professor já se encontra Com uma Materia !");
                                                Console.WriteLine("deseja verificar outro Professor? 1-SIM | 2-NÃO");
                                                opcao = Console.ReadLine();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Deseja Cadastrar uma Materia ao Professor? 1-SIM | 2-NÃO");

                                                opcao = Console.ReadLine();
                                                if (opcao == "1")
                                                {
                                                    List<Materia> materia = materiaService.GetMaterias();

                                                    materia.ForEach(materias => Console.WriteLine("Materia: " + materias.Nome + " Id: " + materias.Id));
                                                    Console.WriteLine("Digite o ID da Materia para cadastrar no Professor");
                                                    int idMat = int.Parse(Console.ReadLine());

                                                    bool mate = materiaService.Localizar(idMat);
                                                    if (mate == false)
                                                    {
                                                        Console.WriteLine("Materia com o ID: " + idMat + " não encontrado.");
                                                        Console.WriteLine("deseja tentar novamente 1-SIM | 2-NÃO");
                                                        opcao = Console.ReadLine();

                                                    }
                                                    else
                                                    {

                                                        professorService.CadastrarMateria(idProf, idMat);

                                                        Console.WriteLine("Materia cadastrada ao professor com sucesso!");
                                                        Console.WriteLine("Aperte enter para sair");
                                                        Console.ReadLine();
                                                        Console.Clear();

                                                    }
                                                }

                                            }

                                        }
                                        if (opcao == "1")
                                        {
                                            Console.WriteLine("deseja Cadastrar outro Professor? 1-SIM | 2-NÃO");
                                            opcao = Console.ReadLine();
                                        }
                                    }

                                    Console.Clear();

                                    menu.MenuPrincipal();

                                    break;
                                }
                            case "4":
                                string opcao2 = "1";



                                while (opcao2 == "1")
                                {
                                    Console.WriteLine("Digite o ID que deseja apagar e aperte Enter");

                                    int id = int.Parse(Console.ReadLine());



                                    if (professorService.Remover(id))
                                    {
                                        Console.WriteLine("Professor removido com sucesso!");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Professor com o id: " + id + " Não encontrado!");
                                        Console.ReadLine();

                                    }

                                    Console.Clear();
                                    Console.WriteLine("Deseja remover outro ID?  1-SIM | 2-NÃO");
                                    opcao2 = Console.ReadLine();

                                }

                                Console.Clear();

                                menu.MenuPrincipal();

                                break;

                            case "5":
                                Console.Clear();
                                menu.MenuPrincipal();

                                break;
                            default:

                                Console.WriteLine("Digite uma opção valida");
                                Console.WriteLine("Aperte Enter para continuar");
                                Console.ReadLine();
                                Console.Clear();
                                menu.MenuProfessor();
                                break;
                        }

                        break;

                    case "3":


                        menu.MenuCurriculo();


                        switch (Console.ReadLine())
                        {


                            case "1":

                                string opcao3 = "1";

                                while (opcao3 == "1")
                                {


                                    Console.Write("Nome: ");
                                    string nome = Console.ReadLine();

                                    if (materiaService.Cadastrar(nome))
                                    {
                                        Console.WriteLine("Materia cadastrada com sucesso!");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Materia " + nome + " já cadastrado!");
                                        Console.ReadLine();
                                    }

                                    Console.WriteLine("Deseja inserir outro dado? 1-SIM | 2-NÃO");
                                    opcao3 = Console.ReadLine();

                                }

                                break;

                            case "2":
                                string opcao2 = "1";

                                while (opcao2 == "1")
                                {
                                    Console.WriteLine("Digite o ID que deseja apagar e aperte Enter");

                                    int id = int.Parse(Console.ReadLine());

                                    if (materiaService.Remover(id))
                                    {
                                        Console.WriteLine("Materia removida com sucesso!");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Materia com o id: " + id + " Não encontrado!");
                                        Console.ReadLine();
                                    }


                                    Console.Clear();
                                    Console.WriteLine("Deseja remover outro ID?  1-SIM | 2-NÃO");
                                    opcao2 = Console.ReadLine();

                                }
                                menu.MenuCurriculo();

                                break;

                            case "3":
                                Console.Clear();
                                menu.MenuPrincipal();

                                break;

                            default:

                                Console.WriteLine("Digite uma opção valida");
                                Console.WriteLine("Aperte Enter para continuar");
                                Console.ReadLine();
                                Console.Clear();
                                menu.MenuCurriculo();
                                break;
                        }

                        Console.Clear();
                        menu.MenuPrincipal();

                        break;

                    case "4":

                        menu.MenuFinancia();
                        switch (Console.ReadLine())
                        {


                            case "1":

                                List<Professor> professores = professorService.getProfessor().FindAll(delegate (Professor p) { return p.Status == "Pendente"; });

                                professores.ForEach(professor => Console.WriteLine("Nome: " + professor.Nome + " Status de Pagamento: " + professor.Status + " Id: " + professor.Id));

                                Console.WriteLine("Aperte Enter para continuar!");
                                Console.ReadLine();
                                Console.Clear();

                                menu.MenuPrincipal();
                                break;

                            case "2":

                                List<Aluno> alunos = alunoService.getAlunos().FindAll(aluno => aluno.Status == "Pendente");

                                alunos.ForEach(aluno => Console.WriteLine("Nome: " + aluno.Nome + " Status de Pagamento: " + aluno.Status + " Id: " + aluno.Id));

                                Console.WriteLine("Aperte Enter para continuar!");
                                Console.ReadLine();
                                Console.Clear();

                                menu.MenuPrincipal();
                                break;

                            case "3":
                                {


                                    string opcao = "1";
                                    while (opcao == "1")
                                    {
                                        Console.WriteLine("Digite o ID do Aluno e aperte Enter");
                                        int id = int.Parse(Console.ReadLine());


                                        bool aluno = alunoService.localizarP(id);
                                        bool alunoss = alunoService.StatusFinan(id);

                                        if (aluno == false)
                                        {
                                            Console.WriteLine("Aluno com o ID: " + id + " não encontrado.");
                                            Console.WriteLine("deseja verificar outro Aluno? 1-SIM | 2-NÃO");
                                            opcao = Console.ReadLine();
                                        }
                                        else
                                        {
                                            if (alunoss == true)
                                            {
                                                Console.WriteLine("Aluno já se encontra Pago.");
                                                Console.WriteLine("deseja verificar outro Aluno? 1-SIM | 2-NÃO");
                                                opcao = Console.ReadLine();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Deseja dar baixa no Aluno? 1-SIM | 2-NÃO");

                                                opcao = Console.ReadLine();
                                                if (opcao == "1")
                                                {
                                                    alunoService.PagarAluno(id);
                                                    Console.WriteLine("Status financeiro do Aluno com o ID: " + id + " Pago com sucesso!");
                                                    Console.WriteLine("Aperte enter para sair");
                                                    Console.ReadLine();
                                                    Console.Clear();
                                                    Console.WriteLine("deseja verificar outro Aluno? 1-SIM | 2-NÃO");
                                                    opcao = Console.ReadLine();

                                                }
                                            }


                                        }


                                    }
                                    Console.WriteLine("Aperte Enter para continuar!");
                                    Console.ReadLine();
                                    Console.Clear();

                                    menu.MenuPrincipal();


                                    break;
                                }
                            case "4":
                                {

                                    string opcao = "1";
                                    while (opcao == "1")
                                    {
                                        Console.WriteLine("Digite o ID do Professor e aperte Enter");
                                        int id = int.Parse(Console.ReadLine());


                                        bool professor = professorService.localizarP(id);
                                        bool professorS = professorService.StatusFinan(id);

                                        if (professor == false)
                                        {
                                            Console.WriteLine("Professor com o ID: " + id + " não encontrado.");
                                            Console.WriteLine("deseja verificar outro Professor? 1-SIM | 2-NÃO");
                                            opcao = Console.ReadLine();
                                        }
                                        else
                                        {
                                            if (professorS == true)
                                            {
                                                Console.WriteLine("Professor já se encontra Pago.");
                                                Console.WriteLine("deseja verificar outro Professor? 1-SIM | 2-NÃO");
                                                opcao = Console.ReadLine();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Deseja Pagar o Sálario do Professor? 1-SIM | 2-NÃO");

                                                opcao = Console.ReadLine();
                                                if (opcao == "1")
                                                {
                                                    professorService.PagarProfe(id);
                                                    Console.WriteLine("Sálario do professor com o ID: " + id + " Pago com sucesso!");
                                                    Console.WriteLine("Aperte enter para sair");
                                                    Console.ReadLine();
                                                    Console.Clear();
                                                    Console.WriteLine("deseja verificar outro Professor? 1-SIM | 2-NÃO");
                                                    opcao = Console.ReadLine();

                                                }
                                            }


                                        }


                                    }
                                    Console.WriteLine("Aperte Enter para continuar!");
                                    Console.ReadLine();
                                    Console.Clear();

                                    menu.MenuPrincipal();

                                    break;

                                }

                            case "5":
                                Console.Clear();
                                menu.MenuPrincipal();

                                break;

                            default:

                                Console.WriteLine("Digite uma opção valida");
                                Console.WriteLine("Aperte Enter para continuar");
                                Console.ReadLine();
                                Console.Clear();
                                menu.MenuFinancia();
                                break;

                        }

                        break;
                    default:

                        Console.WriteLine("Digite uma opção valida");
                        Console.WriteLine("Aperte Enter para continuar");
                        Console.ReadLine();
                        Console.Clear();
                        menu.MenuPrincipal();
                        break;
                }
            }

            while (true);
        }
    }
}

