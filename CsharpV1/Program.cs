using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpV1
{



    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("# # # # #     # # # #   # # # #   # # # # #");
            Console.WriteLine("    #         #         #             #    ");
            Console.WriteLine("    #         # # # #   # # # #       #    ");
            Console.WriteLine("    #         #               #       #    ");
            Console.WriteLine("    #         # # # #   # # # #       #    ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("                                                                                ");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("************");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("1.Create new Trainer");
            Console.WriteLine("2.Create new Questions");
            Console.WriteLine("3.Start the validation");
            Console.WriteLine("4.Show each Trainers");
            Console.WriteLine("5.Show each Questions");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("************");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Make your choice:type 1,2,... or 5 for exit");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("************");

            Console.BackgroundColor = ConsoleColor.Black;
            string inputstring = Console.ReadLine();
            int inputint = int.Parse(inputstring);

            int continue_program = 0;
            do
            {
                     int stop1 = 1;
                do
                {
                    if (inputint == 1)
                    {
                        using (ZHOUYIEntities storedata = new ZHOUYIEntities())
                        {
                            Teacher trainer = new Teacher();

                            Random rad = new Random();
                            int emailaddress = rad.Next(100000, 999999);
                            trainer.E_mail = emailaddress.ToString() + "@supinfo.com"; 

                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("ID");
                            trainer.Id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Name");
                            trainer.Name = Console.ReadLine();
                            Console.WriteLine("Firstname");
                            trainer.Firstname = Console.ReadLine();
                            Console.WriteLine("Promotion during validation");
                            trainer.Promotion_during_validation = Console.ReadLine();
                            Console.WriteLine("Current Promotion");
                            trainer.Current_Promotion = Console.ReadLine();
                            Console.WriteLine("E-mail is " + trainer.E_mail);
                            Console.WriteLine("Campus");
                            trainer.Campus = Console.ReadLine();
                            Console.WriteLine("Courses that he would teach");
                            trainer.Courses_would_teach = Console.ReadLine();
                            Console.WriteLine("Courses that he already teach");
                            trainer.Courses_already_teach = Console.ReadLine();
                            Console.WriteLine("The campus on which he has already given a course");
                            trainer.Campus_already_in = Console.ReadLine();
                            Console.WriteLine("The campus on which he would give a course");
                            trainer.Campus_would_in = Console.ReadLine();

                            storedata.Teacher.Add(trainer);
                            storedata.SaveChanges();

                            Console.WriteLine("If you want to add new tranier once more, please input 1,otherwise input 0");

                            Console.WriteLine("Do you want to exit the program?1 for yes; 0 for no");
                            continue_program = int.Parse(Console.ReadLine());
                        }
                    }
                } while (inputint == 1 && stop1 ==1);

                int stop2 = 0;

                
                    if (inputint == 2)
                    {
                        do
                       {
                        using (ZHOUYIEntities storedata = new ZHOUYIEntities())
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Questions questions = new Questions();
                            Console.WriteLine("Input the ID of quesitions");
                            questions.Id = int.Parse(Console.ReadLine());
                            Console.WriteLine("What subject does this question belong to?Input  'Math' or 'English'?");
                            questions.subject = Console.ReadLine();
                            Console.WriteLine("Please input the question");
                            questions.Q = Console.ReadLine();
                            Console.WriteLine("Please input the answer");
                            questions.A = Console.ReadLine();
                            Console.WriteLine("What type is this question?Input 'important' or 'bonus'");
                            questions.Question_type = Console.ReadLine();
                            storedata.Questions.Add(questions);
                            storedata.SaveChanges();
                            Console.WriteLine("If you want to add question once more, please input 1,otherwise input 0");
                            stop2 = int.Parse(Console.ReadLine());
                            Console.WriteLine("Do you want to exit the program?1 for yes; 0 for no");
                            continue_program = int.Parse(Console.ReadLine());
                        }
                    }while (inputint == 2 && stop2 == 1);//control loop input
                } 



                // bool firstrun = false;//should be true when the program is the first time running
                using (ZHOUYIEntities storedata = new ZHOUYIEntities())
                {
                    if (inputint == 3)
                    {

                        /* if (firstrun == true)
                         {
                             using (ZHOUYIEntities storedata = new ZHOUYIEntities())
                             {
                         
                                 Course course = new Course();
                                 course.Id = 1;
                                 course.Course_name = "Chinese";
                                 storedata.Course.Add(course);
                                 storedata.SaveChanges();
                             }

                             using (ZHOUYIEntities storedata = new ZHOUYIEntities())
                             {
                                 Console.BackgroundColor = ConsoleColor.Black;
                                 Course course = new Course();
                                 course.Id = 2;
                                 course.Course_name = "Math";
                                 storedata.Course.Add(course);
                                 storedata.SaveChanges();
                             }
                             using (ZHOUYIEntities storedata = new ZHOUYIEntities())
                             {
                                 Console.BackgroundColor = ConsoleColor.Black;
                                 Course course = new Course();
                                 course.Id = 3;
                                 course.Course_name = "English";
                                 storedata.Course.Add(course);
                                 storedata.SaveChanges();
                             }
                             firstrun = false;
                         }*/
                        int average = 0;
                        Console.WriteLine("The ID of the trainer is");
                        string input_trainer_id = Console.ReadLine();
                        Console.WriteLine("Which course do you want to test?Chinese？Math?English?");
                        string input_trainer_course = Console.ReadLine();
                        Console.WriteLine("Now the FP will have a small view of questions about " + input_trainer_course);
                        String ConnectionString = @"data source=(LocalDB)\v11.0;attachdbfilename=E:\法方课\C#miniproject\CsharpV1\CsharpV1\C#v1.mdf;integrated security=True;MultipleActiveResultSets=true;";
                        SqlConnection connection = new SqlConnection(ConnectionString);

                        if (input_trainer_course.ToString() == "English")
                        {
                            
                            string sql = "SELECT Q,Id From Questions WHERE subject ='English' ";
                            SqlCommand command = new SqlCommand(sql, connection);
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                String Q = reader["Q"].ToString();
                                String Id = reader["Id"].ToString();
                                Console.Write(Q);
                                Console.WriteLine(Id);

                            }
                            connection.Close();
                        }

                 
                        if (input_trainer_course.ToString() == "Math")
                        {
                            string sql = "SELECT Q,Id From Questions WHERE subject ='Math' ";
                            SqlCommand command = new SqlCommand(sql, connection);
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                String Q = reader["Q"].ToString();
                                String Id = reader["Id"].ToString();
                                Console.Write(Q);
                                Console.WriteLine(Id);

                            }
                            connection.Close();
                        }

                        Console.WriteLine("Which questions does FP want to pick for trainer?Please input the Id(FP can pick up 4 questions in total)");

                        int[] pick_question_Id;
                        pick_question_Id = new int[4];
                        for (int i = 0; i <= 3; i++)
                        { pick_question_Id[i] = int.Parse(Console.ReadLine()); }

                        int sum = 0;
                        for (int i = 0; i <= 3; i++)
                        {
                            
                                string ask = "SELECT Q From Questions WHERE Id = " + pick_question_Id[i];
                                SqlCommand cmd_question = new SqlCommand(ask, connection);
                                connection.Open();
                                SqlDataReader reader1 = cmd_question.ExecuteReader();
                                 while (reader1.Read())
                                 {
                                 String Q = reader1["Q"].ToString();
                                 Console.Write(Q);
                                 }
                            
                                String answer_of_trainer;
                                answer_of_trainer = Console.ReadLine().ToString();
                                string answer = "SELECT A From Questions WHERE Id = " + pick_question_Id[i];
                                SqlCommand cmd_answer = new SqlCommand(answer, connection);
                                reader1 = cmd_answer.ExecuteReader();
                            
                                 while (reader1.Read())
                                 {
                                         String A = reader1["A"].ToString();
                                        // Console.WriteLine("Answer from database is" + A);
                                       //  Console.WriteLine("Answer from input is" + answer_of_trainer);
                                         int answer_of_trainer_int = int.Parse(answer_of_trainer);
                                         int A_int = int.Parse(A);
                                       // int compare_result = 1;
                                       // compare_result = A.CompareTo(answer_of_trainer);
                                       // Console.WriteLine("compare_result=" + compare_result);  
                                        // I think the same string but really unequal,that confuse me, I don't know why
                                        if (A_int==answer_of_trainer_int)//if right
                                        {
                                            int each_mark = 5;
                                             Notation score_each_question = new Notation();
                                            score_each_question.Id = i;
                                            score_each_question.score = each_mark;
                                            storedata.Notation.Add(score_each_question);
                                            sum = sum + each_mark;  
                                        }  
                                }
                         // storedata.SaveChanges();
                            reader1.Close();
                            connection.Close();
                            Console.WriteLine(sum);
                           
                        }
             
                        String grade="0";
                        average = sum / 4;
                        if ( average<=20&&average>= 15 )
                        { grade="A";}
                        if (average <= 14 && average >= 10)
                        { grade = "B"; }
                        if (average <= 9 && average >= 0)
                        { grade = "C"; }
                        Console.WriteLine("the grade of this trainer is");
                        Console.WriteLine(grade);

                        Console.WriteLine("Do you want to exit the program?1 for yes; 0 for no");
                        continue_program = int.Parse(Console.ReadLine());
                        Console.ReadKey();
                    }//if right )

                }



                if (inputint == 4)
                {
                    
                    String ConnectionString = @"data source=(LocalDB)\v11.0;attachdbfilename=E:\法方课\C#miniproject\CsharpV1\CsharpV1\C#v1.mdf;integrated security=True;MultipleActiveResultSets=true;";
                    SqlConnection connection4 = new SqlConnection(ConnectionString);
                    string sql = "SELECT * From Teacher";
                    SqlCommand command = new SqlCommand(sql, connection4);
                    connection4.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        String ID = reader["Id"].ToString();
                        String Name = reader["Name"].ToString();
                        String Firstname = reader["Firstname"].ToString();
                        //String Promotion_during_validation = reader["Promotion_during_validation"].ToString();
                        //String Current_Promotion = reader["Current_Promotion"].ToString();
                        String E_mail = reader["E-mail"].ToString();
                        //String Campus = reader["Campus"].ToString();
                        //String Courses_would_teach = reader["Courses_would_teach"].ToString();
                       // String Courses_already_teach = reader["Courses_already_teach"].ToString();
                        //String Campus_already_in = reader["Campus_already_in"].ToString();
                        //String Campus_would_in = reader["Campus_would_in"].ToString();
                        Console.WriteLine("ID:"+ID);
                        Console.WriteLine("Name:"+Name);
                        Console.WriteLine("Firstname:"+Firstname);
                       // Console.Write(Promotion_during_validation);
                        //Console.Write(Current_Promotion);
                        Console.WriteLine("E_mail:"+E_mail);
                        //Console.Write(Campus);
                       // Console.Write(Courses_would_teach);
                       // Console.Write(Courses_already_teach);
                       // Console.Write(Campus_already_in);
                        //Console.WriteLine(Campus_would_in);

                        
                    }
                    connection4.Close();
                    Console.WriteLine("Do you want to exit the program?1 for yes; 0 for no");
                    continue_program = int.Parse(Console.ReadLine());
                    Console.ReadKey();
                }

                if (inputint == 5)
                {
                    String ConnectionString = @"data source=(LocalDB)\v11.0;attachdbfilename=E:\法方课\C#miniproject\CsharpV1\CsharpV1\C#v1.mdf;integrated security=True;MultipleActiveResultSets=true;";
                    SqlConnection connection5 = new SqlConnection(ConnectionString);
                    string sql = "SELECT * From Questions";
                    SqlCommand command = new SqlCommand(sql, connection5);
                    connection5.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    /*using (ZHOUYIEntities storedata = new ZHOUYIEntities())
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        IQueryable<string> Qs_of_questions = storedata.Questions.Select(p => p.Q);
                        Console.WriteLine("show each Questions");
                        foreach (String Q_of_questions in Qs_of_questions)
                        {
                            Console.WriteLine(Q_of_questions);
                        }
                        Console.ReadKey();//pause
                    }*/
                    while (reader.Read())
                    {
                        String ID = reader["Id"].ToString();
                        String Q = reader["Q"].ToString();
                        String A = reader["A"].ToString();
                        String Question_type = reader["Question_type"].ToString();
                        //String Current_Promotion = reader["Current_Promotion"].ToString();
                        String subject = reader["subject"].ToString();
                        //String Campus = reader["Campus"].ToString();
                        //String Courses_would_teach = reader["Courses_would_teach"].ToString();
                        // String Courses_already_teach = reader["Courses_already_teach"].ToString();
                        //String Campus_already_in = reader["Campus_already_in"].ToString();
                        //String Campus_would_in = reader["Campus_would_in"].ToString();
                        Console.WriteLine("ID:" + ID);
                        Console.WriteLine("Question:" + Q);
                        Console.WriteLine("Answer:" + A);
                         //Console.Write(Promotion_during_validation);
                        //Console.Write(Current_Promotion);
                        Console.Write("Question_type" + Question_type);
                        Console.WriteLine("subject:"+subject);
                        // Console.Write(Courses_would_teach);
                        // Console.Write(Courses_already_teach);
                        // Console.Write(Campus_already_in);
                        //Console.WriteLine(Campus_would_in);


                    }
                    connection5.Close();

                    Console.WriteLine("Do you want to exit the program?1 for yes; 0 for no");
                    continue_program = int.Parse(Console.ReadLine());
                    Console.ReadKey();
                }
            } while (continue_program == 0);
        }
      }
    }