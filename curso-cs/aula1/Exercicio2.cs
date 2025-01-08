
using System;
namespace LearningCSharp{
   class program {
     public static void despedida (params string [] alunos) {
     
          foreach(var aluno in alunos){
             Console.WriteLine("Tchau {0}, até a próxima aula", aluno);
           }
       }
       
       static void Main(){
           despedida("João", "Antônio", "Thiago");
       }
   }
}