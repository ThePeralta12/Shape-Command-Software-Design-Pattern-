//Name: Carl Peralta
//18315304
//Date: 27th November 2020
//OS: Windows 10
//VSCode
//Command Software Design Pattern


    using System;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;

    namespace MyShape
    {
        class Program
        {
            public class Circle : Shape //The Circle class
            {
                public int X { get; set; }  // circle centre x-coordinate
                public int Y { get; set; }  // circle centre y-coordinate
                public int R { get; set; }  // circle radius

                public Circle(int x, int y, int r) { X = x; Y = y; R = r; } //user input

                public override string ToString()
                {
                    // convert the object to an SVG element descriptor string for circle
                    string dispSVG = String.Format(@"   <circle cx=""{0}"" cy=""{1}"" r=""{2}"" stroke=""black"" stroke-width=""2"" fill=""yellow""/>", X, Y, R);
                    return dispSVG;
                }
            }
            
            public class Rectangle : Shape // The Rectangle Class
            {
                public int X { get; set; }  // rect top left x-coordinate
                public int Y { get; set; }  // rect top left y-coordinate
                public int H { get; set; }  // rect height
                public int W { get; set; }  // rect width
                
                public Rectangle(int x, int y, int h, int w) { X = x; Y = y; H = h; W = w; } //user input

                public override string ToString()
                {
                    // convert the object to an SVG element descriptor string for circle
                    string dispSVG = String.Format(@"   <rect x=""{0}"" y=""{1}"" height=""{2}"" width=""{3}"" stroke=""black"" stroke-width=""2"" fill=""yellow""/>", X, Y, H, W);
                    return dispSVG;
                }
            }
            

            public class Ellipse : Shape //The Ellipse class
            {
                public int X { get; set; }  // ellipse centre x-coordinate
                public int Y { get; set; }  // ellipse centre y-coordinate
                public int RX { get; set; } // ellipse x rad
                public int RY { get; set; } // ellipse y rad 

                public Ellipse(int x, int y, int rx, int ry) { X = x; Y = y; RX = rx; RY = ry; } //user input

                public override string ToString()
                {
                    // convert the object to an SVG element descriptor string for circle
                    string dispSVG = String.Format(@"   <ellipse cx=""{0}"" cy=""{1}"" rx=""{2}"" ry=""{3}"" stroke=""black"" stroke-width=""2"" fill=""red""/>", X, Y, RX, RY);
                    return dispSVG;
                }
            }

            public class Line : Shape //The Line class
            {
                public int X1 { get; set; }  // rect top left x-coordinate
                public int Y1 { get; set; }  // rect top left y-coordinate
                public int X2 { get; set; }  // rect height
                public int Y2 { get; set; }  // rect width

                public Line(int x1, int y1, int x2, int y2) { X1 = x1; Y1 = y1; X2 = x2; Y2 = y2; } //user input

                public override string ToString()
                {
                    // convert the object to an SVG element descriptor string for circle
                    string dispSVG = String.Format(@"   <line x1=""{0}"" y1=""{1}"" x2=""{2}"" y2=""{3}"" stroke=""black"" stroke-width=""2"" fill=""green""/>", X1, Y1, X2, Y2);
                    return dispSVG;
                }
            }

            public class Polyline : Shape //The Polyline class
            {
                public string Points { get; set; }
                public Polyline() { Points = "0,40 40,40 40,80 80,80 80,120 120,120 120,160"; } //default constructer
                //https://www.w3schools.com/graphics/svg_polyline.asp
                public Polyline(string points) { Points = points; } //user input

                public override string ToString()
                {
                    // convert the object to an SVG element descriptor string for circle
                    string dispSVG = String.Format(@"   <polyline points=""{0}"" stroke=""black"" stroke-width=""2"" fill=""yellow""/>", Points);
                    return dispSVG;
                }
            }

            public class Polygon : Shape //The Polygon class
            {
                public string Points { get; set; }
                public Polygon() { Points = "20,20 40,25 60,40 80,120 120,140 200,180"; } //default constructer
                //https://www.w3schools.com/graphics/svg_polygon.asp
                public Polygon(string points) { Points = points; } //user input

                public override string ToString()
                {
                    // convert the object to an SVG element descriptor string for circle
                    string dispSVG = String.Format(@"   <polygon points=""{0}"" stroke=""black"" stroke-width=""2"" fill=""green""/>", Points);
                    return dispSVG;
                }
            }

            public class Path : Shape // The Path class
            {
                public string Points { get; set; }
                public Path() { Points = "M150 150 L75 350 L225 350 Z"; } //default constructer
                //https://www.w3schools.com/graphics/svg_path.asp
                public Path(string points) { Points = points; } //user input

                public override string ToString()
                {
                    // convert the object to an SVG element descriptor string for circle
                    string dispSVG = String.Format(@"   <path d=""{0}"" stroke=""black"" stroke-width=""2"" fill=""blue""/>", Points);
                    return dispSVG;
                }
            }

            public class Canvas //This is the Canvas Class
            {
                private Stack<Shape> canvas = new Stack<Shape>(); //Calling canvas as a Stack.
                public void Add(Shape s) // This is the Add Function
                {
                    canvas.Push(s);
                    Console.WriteLine("Added Shape to canvas: {0}" + Environment.NewLine, s);
                }

                public Shape Remove() //This is the Remove Function
                {
                    Shape s = canvas.Pop();
                    Console.WriteLine("Removed Shape from canvas: {0}" + Environment.NewLine, s);
                    return s;
                }

                internal void MakeEmpty() //The is the MakeEmpty method
            {
                //Command to clear the canvas
                canvas.Clear();
                //informs the user that the canvas is cleared
                Console.WriteLine("Successfully cleared your canvas");
            }
                public Canvas() // This creates the Canvas method
                {
                    Console.WriteLine("\nCreated a new Canvas!");
                    Console.WriteLine();
                }

                public override string ToString()
                {
                    String str = "" + Environment.NewLine;
                    foreach (Shape s in canvas)
                    {
                        str += s + Environment.NewLine;
                    }
                    return str;
                }
            }

            public abstract class Shape //this the Shape Method
            {
                public override string ToString()
                {
                    return "Shape!";
                }
            }



            //This is the Invoker Class
            public class User{
                private Stack<Command> undo; 
                private Stack<Command> redo;

        
                public User()
                {
                    Reset();
                    Console.WriteLine("Created a new User!" + Environment.NewLine);
                }
                public void Reset()
                {
                    undo = new Stack<Command>();
                    redo = new Stack<Command>();
                }
                public void Action(Command command)
                {
                    // first update the undo - redo stacks
                    undo.Push(command);  // save the command to the undo command
                    redo.Clear();        // once a new command is issued, the redo stack clears

                    // next determine  action from the Command object type
                    // this is going to be AddShapeCommand or DeleteShapeCommand
                    Type t = command.GetType();
                    if (t.Equals(typeof(AddShapeCommand)))
                    {
                        Console.WriteLine("Command Received: Add new Shape!" + Environment.NewLine);
                        command.Do();
                    }
                    if (t.Equals(typeof(DeleteShapeCommand)))
                    {
                        Console.WriteLine("Command Received: Delete last Shape!" + Environment.NewLine);
                        command.Do();
                    }
                }
                // This is the Undo method
            
                public void Undo()
                {
                    Console.WriteLine("Undoing operation!"); Console.WriteLine();
                    if (undo.Count > 0)
                    {
                        Command c = undo.Pop(); c.Undo(); redo.Push(c);
                    }
                }
                // This is the Redo method
                public void Redo()
                {
                    Console.WriteLine("Redoing operation!"); Console.WriteLine();
                    if (redo.Count > 0)
                    {
                        Command c = redo.Pop(); c.Do(); undo.Push(c);
                    }
                }
            }
            // Abstract Command (Command) class - commands can do something and also undo
            public abstract class Command
            {
                public abstract void Do();     // what happens when we execute (do)
                public abstract void Undo();   // what happens when we unexecute (undo)
            }
            // Add Shape Command - it is a ConcreteCommand Class (extends Command)
            // This adds a Shape (Circle) to the Canvas as the "Do" action
            public class AddShapeCommand : Command
            {
                Shape shape;
                Canvas canvas;

                public AddShapeCommand(Shape s, Canvas c)
                {
                    shape = s;
                    canvas = c;
                }

                // Adds a shape to the canvas as "Do" action
                public override void Do()
                {
                    canvas.Add(shape);
                }
                // Removes a shape from the canvas as "Undo" action
                public override void Undo()
                {
                    shape = canvas.Remove();
                }

            }

            // Delete Shape Command - it is a ConcreteCommand Class (extends Command)
            // This deletes a Shape (Circle) from the Canvas as the "Do" action
            public class DeleteShapeCommand : Command
            {

                Shape shape;
                Canvas canvas;

                // Removes a shape from the canvas as "Do" action
                public override void Do()
                {
                    shape = canvas.Remove();
                }

                // Restores a shape to the canvas a an "Undo" action
                public override void Undo()
                {
                    canvas.Add(shape);
                }
            }

            static void Main(string[] args)
            {
                Random rnd = new Random(); // random number generator
                List<String> Shapes = new List<String>(); //create list to hold shapes

                Canvas canvas = new Canvas();

                User user = new User();
                Console.WriteLine("Welcome to the Canvas!");
                Console.WriteLine("Please Help to start!");
               
                while (true) {
                    string sc = Console.ReadLine();
                    if (sc.Equals("quit") || sc.Equals("Quit")){
                        Console.WriteLine("System is shutting down! ");
                        break;
                    } else {
                        switch(sc)
                        {
                            case "A Rectangle":
                            user.Action(new AddShapeCommand(new Rectangle(rnd.Next(1, 500), rnd.Next(1, 500), rnd.Next(1, 500), rnd.Next(1, 500)), canvas));
                                Console.WriteLine("Rectangle was added to you canvas");
                                break;
                            case "Add Circle":
                            user.Action(new AddShapeCommand(new Circle(rnd.Next(1, 500), rnd.Next(1, 500), rnd.Next(1, 500)), canvas));
                                Console.WriteLine("Circle was added to you canvas");
                                break;
                            case "Add Ellipse":
                            user.Action(new AddShapeCommand(new Ellipse(rnd.Next(1, 500), rnd.Next(1, 500), rnd.Next(1, 500), rnd.Next(1, 500)), canvas));
                                Console.WriteLine("Ellipse was added to your canvas!");
                                break;
                            case "Add Line":
                            user.Action(new AddShapeCommand(new Line(rnd.Next(1, 500), rnd.Next(1, 500), rnd.Next(1, 500), rnd.Next(1, 500)), canvas));
                                Console.WriteLine("Line was added to your canvas!");
                                break;
                            case "Add Polyline":
                            user.Action(new AddShapeCommand(new Polyline(), canvas));
                                Console.WriteLine("Polyline was added to your canvas!");
                                break;
                            case "Add Polygon":
                            user.Action(new AddShapeCommand(new Polygon(), canvas));
                                Console.WriteLine("Polygon was added to your canvas!");
                                break;
                            case "Add Path":
                            user.Action(new AddShapeCommand(new Path(), canvas));
                                Console.WriteLine("Path was added to your added");
                                break;
                            case "Undo":
                                user.Undo();
                                break;
                            case "Redo":
                                user.Redo();
                                break;
                            case "Clear":
                                canvas.MakeEmpty();
                                break;
                            case "Display":
                                Console.WriteLine(canvas);
                                break;
                            case "Help":
                                Console.WriteLine("Commands: ");
                                Console.WriteLine("  Add <shape>    Add <shape> to canvas");
                                Console.WriteLine("  Undo           Undo last operation");
                                Console.WriteLine("  Redo           Redo last operation");
                                Console.WriteLine("  Display        Display Canvas");
                                Console.WriteLine("  Save           Save canvas to SVG file");
                                Console.WriteLine("  Clear          Clear canvas");
                                Console.WriteLine("  Quit           Quit application");
                                break;
                            case "Save":
                                String path = @"./Shapes.svg";
                                //https://docs.microsoft.com/en-us/dotnet/api/system.io.file.create?view=net-5.0
                                using (FileStream fs = File.Create(path))
                                {
                                    // insert open svg tag into first line
                                    byte[] info = new UTF8Encoding(true).GetBytes(@"<svg height=""1000"" width=""1000"" xmlns=""http://www.w3.org/2000/svg"">" + canvas);
                                    // Add some information to the file.
                                    fs.Write(info, 0, info.Length);
                                }
                                //add close tag to the end
                                using (StreamWriter sw = File.AppendText(path))
                                {
                                    sw.WriteLine("</svg>");
                                }
                                Console.WriteLine("Canvas saved to SVG!");
                                break;
                            default:
                                Console.WriteLine("Invalid Input");
                                break;
                        }
                    }
                }
            }
        }
    }
