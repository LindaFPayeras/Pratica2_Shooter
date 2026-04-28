// using System;

// public class TestClass 
// {
//     // [Modificador public/private]

//     public int testInt; // Variável do tipo int
//     // [Modificador public/private] tipoDeDato nombrePropiedad

//     private int testIntPoperty { get; set; } // Propriedade do tipo int
//     /* Forma de acceder a la variable de manera controlada, mejor que sea privado
//     asi tiene que pasar por el método get*/

//     // [modificador public/private] tipoDeDato nombreMetodo (parámetros)
//     public int getTestInt() // Método com retorno e sem parámetros
//     {
//         return testInt;
//     }

    

// }

// class Persona
// {
//     // Campo
//     private string dni;
//     public DateTime fechaNacimiento;

//     // Propiedad --> cosas publicas a las que voy a acceder
//     public string nombre { get; set; }
//     // Metodo

//     public Persona(string nombre, DateTime fechaNacimiento) // Constructor de la clase
//     /* Para poner valores por defecto y no tener que hacer un constructor por
//     variable se pone tal que sting nombre ="" asi es una cadena vacia. El date por ejemplo
//     tienes que ponerlo siempre por defecto, asique DateTime, tiene que ir primero en fila y
//     todo en orden*/
//     {
//         this.nombre = nombre;
//         this.fechaNacimiento = fechaNacimiento;
//     }

//     public void saludar()
//     {
//         Console.WriteLine("Hola, soy " + nombre); //Usamos Debug.Log en Unity para mostrar mensajes en la consola
//         // Debug.Log("Hola, soy " + nombre);
//     }


//     void main() // fuera de la clase, es para ejemplo
//     {
//         Persona persona1 = new Persona("Juan", DateTime.Now); // instancia, mejor ponerlo en el propio constructor
//         // persona1.nombre = "Juan";
//         // persona1.fechaNacimiento = new DateTime(1990, 5, 20);
//         persona1.saludar();

//     }

// }
// ////////////////////
// //    HERENCIAS   //
// ////////////////////

// public class Animal
//     {
//         public void comer() // Si esto es privado, perro no podria comer.
//         /*Si es protected, entonces los hijos pueden acceder, pero desde fuera no*/
//         {
//             Console.WriteLine("El animal está comiendo");
//         }

//         protected virtual void hablar()
//         /*Si quiero que no haya nada por defecto, en vez de virtual será abstract */
//         {
//             Console.WriteLine("El animal está hablando");
//         }
//     }

//     public class Perro : Animal
//     {
//         public void ladrar()
//         {
//             Console.WriteLine("El perro está ladrando");
//         }

//         protected override void hablar()
//         {
//             Console.WriteLine("Guau guau");
//         }

//         public void main2() // fuera de la clase, es para ejemplo
//         {
//             Perro perro1 = new Perro();
//             perro1.comer(); // El perro puede comer porque el método es público
//             perro1.ladrar(); // El perro puede ladrar porque el método es público
//             perro1.hablar(); // El perro no puede hablar porque el método es protegido
//         }
//     }

    
// // herencia anidada

// public class Gato : Animal
//     {
//         public string raza;
//         public bool esDomestico;

//         Gato(string suRaza, bool domestico)
//         {
//             this.raza = suRaza;
//             this.esDomestico = domestico;
//         }

//         public void maullar()
//         {
//             Console.WriteLine("El gato está maullando");
//         }

//         protected override void hablar() // Cambiar el comportamiento del método hablar para los gatos
//         {
//             Console.WriteLine("Miau miau");
//         }

//             /*Usamos override para
//             1- Cambiar el comportamiento sin confundir al metodo
//             2- Polimorfismo -> no neceisto hacer diferenciaciones de tipos dentro de Animal
//             en el momento por ejemplo:*/

//             public void main3() // fuera de la clase, es para ejemplo
//         {
//             base.hablar(); // para que funcione, si fuera en un main de verdad no haria falta, solo con
//             // animal1.hablar() funcionaria. 

//             Animal animal1 = new Animal();
//             animal1.comer(); // El animal puede comer
//             animal1.hablar(); // Dirá "El animal está hablando"
//             animal1 = new Gato("Firulais",true); // Ahora animal1 es un perro
//             animal1.comer(); // El perro puede comer
//             animal1.hablar(); // Dirá "Miau miau" porque el método hablar ha sido sobrescrito en la clase Gato
//         }
    
//     }


// public class Calculadora // es una clase estatica, no puedes instanciar más, cosas globales

// {
//     public static int totalOperaciones = 0;
//     public static int Sumar(int a, int b)
//     {
//         totalOperaciones++; // 
//         return a + b;
//     }

// }