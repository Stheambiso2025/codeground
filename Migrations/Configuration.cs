namespace MyCode.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MyCode.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MyCode.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyCode.Models.AppDbContext context)
        {
            // ============ COURSES ============
            context.Courses.AddOrUpdate(c => c.Id,
                new Course { Id = 1, Title = "Python", Slug = "python", Icon = "🐍", Description = "Perfect for beginners. Simple syntax, powerful results.", OrderIndex = 1 },
                new Course { Id = 2, Title = "Java", Slug = "java", Icon = "☕", Description = "Learn strong programming fundamentals used in real jobs.", OrderIndex = 2 }
            );
            context.SaveChanges();

            // ============ PYTHON LESSONS ============
            context.Lessons.AddOrUpdate(l => l.Id,
                new Lesson
                {
                    Id = 1,
                    CourseId = 1,
                    OrderIndex = 1,
                    Language = "python",
                    Title = "What is Programming?",
                    Content = @"
                        <h4>📖 What is Programming?</h4>
                        <p>Programming is the process of giving a computer instructions to perform a task. Imagine telling a person:</p>
                        <ol>
                            <li>Ask me for my name.</li>
                            <li>Remember my name.</li>
                            <li>Say hello to me.</li>
                        </ol>
                        <p>A computer needs those instructions written in a <strong>programming language</strong>.</p>

                        <h4>🐍 What is Python?</h4>
                        <p>Python is a programming language known for its simple, readable syntax. It's used in automation, web development, data analysis, AI, and more.</p>
                        <p>Compare Python:</p>
                        <pre>print(""Hello World!"")</pre>
                        <p>With Java:</p>
                        <pre>System.out.println(""Hello World!"");</pre>
                        <p>See? Python is shorter and easier to read.</p>

                        <h4>👋 Your First Program</h4>
                        <p>The <code>print()</code> function tells Python to display something.</p>

                        <h4>📝 Strings</h4>
                        <p>A <strong>string</strong> is text. You can use either double quotes or single quotes.</p>

                        <h4>💬 Comments</h4>
                        <p>Comments are notes for humans. Python ignores them. Use <code>#</code> for single-line comments.</p>

                        <h4>🎯 Getting Input</h4>
                        <p>The <code>input()</code> function asks the user for information. <strong>Important:</strong> input() always returns text. Use <code>int()</code> to convert to a number.</p>

                        <div class='alert alert-warning'>
                            <strong>⚠️ Common Mistake:</strong> Forgetting to convert input to a number. 
                            <code>age = int(input(""Enter age: ""))</code> is correct.
                        </div>
                    ",
                    CodeExample = @"# Your first Python program
print(""Hello World!"")

# Variables and input
name = input(""Enter your name: "")
age = int(input(""Enter your age: ""))

print(f""Hello {name}, you are {age} years old."")"
                },
                new Lesson
                {
                    Id = 2,
                    CourseId = 1,
                    OrderIndex = 2,
                    Language = "python",
                    Title = "Variables and Data Types",
                    Content = @"
                        <h4>📦 What is a Variable?</h4>
                        <p>A variable is a named storage location for information. Think of it as a box that holds a value.</p>
                        <p>In Python, we just write <code>age = 20</code>. Python figures out the type automatically.</p>

                        <h4>🔢 Main Python Data Types</h4>
                        <ul>
                            <li><code>int</code> — whole numbers like <code>20</code></li>
                            <li><code>float</code> — decimals like <code>20.5</code></li>
                            <li><code>str</code> — text like ""Thabo""</li>
                            <li><code>bool</code> — either <code>True</code> or <code>False</code> (capital letters!)</li>
                        </ul>

                        <h4>🔍 Check the Type</h4>
                        <p>Use <code>type()</code> to see what type a variable is.</p>

                        <h4>🧮 Arithmetic Operators</h4>
                        <ul>
                            <li><code>+</code> add, <code>-</code> subtract, <code>*</code> multiply, <code>/</code> divide</li>
                            <li><code>//</code> floor division (drops decimals)</li>
                            <li><code>%</code> remainder — great for even/odd checks</li>
                            <li><code>**</code> power — <code>2 ** 3 = 8</code></li>
                        </ul>

                        <h4>🔄 Type Conversion</h4>
                        <p><code>int(""20"")</code> gives 20, <code>float(""19.99"")</code> gives 19.99, <code>str(100)</code> gives ""100""</p>
                    ",
                    CodeExample = @"# Variables
age = 20
price = 99.99
name = ""Thabo""
is_student = True

print(type(age))      # <class 'int'>
print(type(price))    # <class 'float'>

# Arithmetic
a = 10
b = 3

print(a + b)   # 13
print(a / b)   # 3.333...
print(a // b)  # 3
print(a % b)   # 1
print(a ** b)  # 1000"
                },
                new Lesson
                {
                    Id = 3,
                    CourseId = 1,
                    OrderIndex = 3,
                    Language = "python",
                    Title = "If Statements",
                    Content = @"
                        <h4>🔀 Making Decisions</h4>
                        <p>Sometimes a program needs to decide something. That's what <code>if</code> is for.</p>

                        <h4>⭐ Indentation is Critical</h4>
                        <p>Python uses <strong>indentation</strong> (spaces) to show what belongs inside the if block. This is different from Java!</p>
                        <pre>if age &gt;= 18:
    print(""Adult"")   &lt;-- indented, belongs to if</pre>

                        <h4>🛤️ if / else / elif</h4>
                        <p>Use <code>else</code> for the ""otherwise"" case, and <code>elif</code> for extra conditions.</p>

                        <h4>⚖️ Comparison Operators</h4>
                        <ul>
                            <li><code>==</code> equal to (comparison)</li>
                            <li><code>!=</code> not equal</li>
                            <li><code>&gt;</code> <code>&lt;</code> <code>&gt;=</code> <code>&lt;=</code></li>
                        </ul>

                        <div class='alert alert-danger'>
                            <strong>⚠️ Watch out:</strong> <code>=</code> assigns a value. <code>==</code> compares two values. Mixing them up is the #1 beginner mistake.
                        </div>

                        <h4>🔗 Logical Operators</h4>
                        <p>Python uses words: <code>and</code>, <code>or</code>, <code>not</code>.</p>
                    ",
                    CodeExample = @"age = int(input(""Enter your age: ""))

if age >= 18:
    print(""You are an adult"")
else:
    print(""You are a minor"")

# Multiple conditions
mark = 75

if mark >= 75:
    print(""Distinction"")
elif mark >= 50:
    print(""Pass"")
else:
    print(""Fail"")

# Logical operators
day = ""Saturday""

if day == ""Saturday"" or day == ""Sunday"":
    print(""Weekend!"")"
                },
                new Lesson
                {
                    Id = 4,
                    CourseId = 1,
                    OrderIndex = 4,
                    Language = "python",
                    Title = "Loops",
                    Content = @"
                        <h4>🔁 Why Loops?</h4>
                        <p>If you want to print ""Hello"" 100 times, you don't write 100 print statements. You use a loop.</p>

                        <h4>🔢 range()</h4>
                        <ul>
                            <li><code>range(5)</code> gives 0, 1, 2, 3, 4 (stops BEFORE 5)</li>
                            <li><code>range(1, 6)</code> gives 1, 2, 3, 4, 5</li>
                            <li><code>range(1, 11, 2)</code> gives 1, 3, 5, 7, 9</li>
                        </ul>

                        <h4>♾️ while loops</h4>
                        <p>Three parts: <strong>start</strong>, <strong>condition</strong>, <strong>update</strong>. Forgetting the update creates an infinite loop!</p>

                        <h4>⏹️ break and continue</h4>
                        <ul>
                            <li><code>break</code> stops the loop entirely</li>
                            <li><code>continue</code> skips the current iteration</li>
                        </ul>

                        <h4>🎨 Nested Loops</h4>
                        <p>A loop inside a loop — great for patterns and grids.</p>
                    ",
                    CodeExample = @"# for loop
for i in range(1, 6):
    print(i)

# while loop
count = 1
while count <= 5:
    print(count)
    count += 1

# break
for i in range(1, 11):
    if i == 5:
        break
    print(i)

# Only even numbers
for i in range(1, 11):
    if i % 2 == 0:
        print(i)"
                },
                new Lesson
                {
                    Id = 5,
                    CourseId = 1,
                    OrderIndex = 5,
                    Language = "python",
                    Title = "Functions",
                    Content = @"
                        <h4>🧩 What is a Function?</h4>
                        <p>A function is a reusable block of code that performs a task. Define it once, call it whenever you need it.</p>

                        <h4>📝 Defining vs Calling</h4>
                        <p>Defining a function doesn't run it! You must <strong>call</strong> it with <code>()</code>.</p>

                        <h4>📥 Parameters and Arguments</h4>
                        <ul>
                            <li><strong>Parameter</strong> — the name inside the function definition</li>
                            <li><strong>Argument</strong> — the actual value you pass when calling</li>
                        </ul>

                        <h4>↩️ return vs print</h4>
                        <p>This is critical:</p>
                        <ul>
                            <li><code>print()</code> — just displays something (no value returned)</li>
                            <li><code>return</code> — sends a value back to whoever called the function</li>
                        </ul>

                        <div class='alert alert-info'>
                            <strong>💡 Remember:</strong> If a function returns something, you can store it: 
                            <code>result = add(10, 5)</code>. If it only prints, you can't do that.
                        </div>
                    ",
                    CodeExample = @"def greet(name):
    print(""Hello"", name)

greet(""Thabo"")
greet(""John"")

# return
def add(a, b):
    return a + b

answer = add(10, 5)
print(answer)  # 15

# Function with if
def check_age(age):
    if age >= 18:
        return ""Adult""
    else:
        return ""Minor""

print(check_age(20))  # Adult"
                }
            );
            context.SaveChanges();

            // ============ JAVA LESSONS ============
            context.Lessons.AddOrUpdate(l => l.Id,
                new Lesson
                {
                    Id = 6,
                    CourseId = 2,
                    OrderIndex = 1,
                    Language = "java",
                    Title = "Introduction to Java",
                    Content = @"
                        <h4>☕ What is Java?</h4>
                        <p>Java is a programming language used to create desktop apps, web apps, Android apps, banking systems, games, and enterprise software.</p>

                        <h4>👋 Your First Java Program</h4>
                        <p>Every Java program starts with a <code>class</code> and a <code>main</code> method.</p>

                        <h4>🔍 Breaking It Down</h4>
                        <ul>
                            <li><code>public class Main</code> — creates a class called Main</li>
                            <li>Curly brackets <code>{ }</code> group code together</li>
                            <li><code>public static void main(String[] args)</code> — the entry point, where the program starts</li>
                            <li><code>System.out.println()</code> — prints something and moves to a new line</li>
                            <li><code>System.out.print()</code> — prints without moving to a new line</li>
                        </ul>

                        <h4>📥 Getting Input with Scanner</h4>
                        <p>Java uses the <code>Scanner</code> class to read user input. Don't forget to <code>import java.util.Scanner;</code> at the top!</p>
                    ",
                    CodeExample = @"import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        System.out.println(""Hello World!"");

        Scanner input = new Scanner(System.in);

        System.out.print(""Enter your name: "");
        String name = input.nextLine();

        System.out.print(""Enter your age: "");
        int age = input.nextInt();

        System.out.println(""Hello "" + name + "", you are "" + age);
    }
}"
                },
                new Lesson
                {
                    Id = 7,
                    CourseId = 2,
                    OrderIndex = 2,
                    Language = "java",
                    Title = "Variables and Types",
                    Content = @"
                        <h4>📦 Variables in Java</h4>
                        <p>Unlike Python, Java is <strong>strongly typed</strong> — you must say what type each variable is.</p>

                        <h4>🔢 Common Java Types</h4>
                        <ul>
                            <li><code>int</code> — whole number: <code>20</code></li>
                            <li><code>double</code> — decimal: <code>20.5</code></li>
                            <li><code>char</code> — one character: <code>'A'</code> (single quotes!)</li>
                            <li><code>boolean</code> — <code>true</code> or <code>false</code> (lowercase!)</li>
                            <li><code>String</code> — text: ""Thabo"" (double quotes!)</li>
                        </ul>

                        <h4>🔢 Arithmetic</h4>
                        <p>Same operators as Python except power (<code>**</code>). In Java, use <code>Math.pow()</code> instead.</p>

                        <div class='alert alert-warning'>
                            <strong>⚠️ Integer Division Trap:</strong> <code>5 / 2</code> gives <code>2</code>, not <code>2.5</code>. 
                            Use <code>5.0 / 2</code> to get <code>2.5</code>.
                        </div>

                        <h4>🔄 Type Casting</h4>
                        <p><code>(int) 10.99</code> drops the decimal, giving <code>10</code>.</p>
                    ",
                    CodeExample = @"int age = 20;
double price = 99.99;
char grade = 'A';
boolean isStudent = true;
String name = ""Thabo"";

// Arithmetic
int a = 10;
int b = 3;

System.out.println(a + b);       // 13
System.out.println(a / b);       // 3 (integer division!)
System.out.println(5.0 / 2);     // 2.5
System.out.println(a % b);       // 1

// Casting
double d = 10.99;
int n = (int) d;
System.out.println(n);           // 10"
                },
                new Lesson
                {
                    Id = 8,
                    CourseId = 2,
                    OrderIndex = 3,
                    Language = "java",
                    Title = "If Statements",
                    Content = @"
                        <h4>🔀 Making Decisions</h4>
                        <p>Java uses <code>if</code>, <code>else if</code>, and <code>else</code> — same idea as Python but with curly braces.</p>

                        <h4>⚖️ Comparison Operators</h4>
                        <ul>
                            <li><code>==</code> equal to</li>
                            <li><code>!=</code> not equal</li>
                            <li><code>&gt;</code> <code>&lt;</code> <code>&gt;=</code> <code>&lt;=</code></li>
                        </ul>

                        <div class='alert alert-danger'>
                            <strong>⚠️ Critical:</strong> <code>=</code> is assignment. <code>==</code> is comparison. Different!
                        </div>

                        <h4>🔗 Logical Operators</h4>
                        <p>Java uses symbols, not words:</p>
                        <ul>
                            <li><code>&amp;&amp;</code> — AND</li>
                            <li><code>||</code> — OR</li>
                            <li><code>!</code> — NOT</li>
                        </ul>

                        <h4>📝 Comparing Strings</h4>
                        <p>In Java, do NOT use <code>==</code> for strings. Use <code>.equals()</code>: <code>name.equals(""John"")</code></p>
                    ",
                    CodeExample = @"int age = 20;

if (age >= 18) {
    System.out.println(""Adult"");
} else {
    System.out.println(""Minor"");
}

// else if
int mark = 75;

if (mark >= 75) {
    System.out.println(""Distinction"");
} else if (mark >= 50) {
    System.out.println(""Pass"");
} else {
    System.out.println(""Fail"");
}

// Logical operators
if (age >= 18 && age <= 30) {
    System.out.println(""Young adult"");
}

// String comparison
String name = ""John"";
if (name.equals(""John"")) {
    System.out.println(""Hello John"");
}"
                },
                new Lesson
                {
                    Id = 9,
                    CourseId = 2,
                    OrderIndex = 4,
                    Language = "java",
                    Title = "Loops in Java",
                    Content = @"
                        <h4>🔁 Three Types of Loops</h4>
                        <ul>
                            <li><code>for</code> — when you know how many times</li>
                            <li><code>while</code> — repeat while condition is true</li>
                            <li><code>do-while</code> — runs at least once, checks after</li>
                        </ul>

                        <h4>🎯 The for Loop</h4>
                        <p>Three parts: <strong>start</strong>; <strong>condition</strong>; <strong>update</strong></p>
                        <pre>for (int i = 1; i &lt;= 5; i++) { }</pre>

                        <h4>♾️ while Loop</h4>
                        <p>Same idea as Python, but with curly braces.</p>

                        <h4>⏹️ break and continue</h4>
                        <ul>
                            <li><code>break</code> — exit the loop</li>
                            <li><code>continue</code> — skip to the next iteration</li>
                        </ul>
                    ",
                    CodeExample = @"// for loop
for (int i = 1; i <= 5; i++) {
    System.out.println(i);
}

// while loop
int count = 1;
while (count <= 5) {
    System.out.println(count);
    count++;
}

// break
for (int i = 1; i <= 10; i++) {
    if (i == 5) break;
    System.out.println(i);
}

// continue
for (int i = 1; i <= 5; i++) {
    if (i == 3) continue;
    System.out.println(i);
}"
                },
                new Lesson
                {
                    Id = 10,
                    CourseId = 2,
                    OrderIndex = 5,
                    Language = "java",
                    Title = "Methods",
                    Content = @"
                        <h4>🧩 What is a Method?</h4>
                        <p>In Java, functions are called <strong>methods</strong> and they live inside a class.</p>

                        <h4>📝 Defining and Calling</h4>
                        <p>Define the method once, then call it by name with <code>()</code>.</p>

                        <h4>📥 Parameters and Arguments</h4>
                        <ul>
                            <li><strong>Parameter</strong> — variable inside the method definition</li>
                            <li><strong>Argument</strong> — the value you pass when calling</li>
                        </ul>

                        <h4>↩️ void vs return</h4>
                        <ul>
                            <li><code>void</code> — returns nothing</li>
                            <li><code>int</code>, <code>String</code>, <code>boolean</code>, etc. — returns a value</li>
                        </ul>

                        <h4>🎯 Method Overloading</h4>
                        <p>Multiple methods with the same name but different parameters.</p>
                    ",
                    CodeExample = @"public class Main {

    // void method
    public static void sayHello() {
        System.out.println(""Hello!"");
    }

    // method with parameter
    public static void greet(String name) {
        System.out.println(""Hello "" + name);
    }

    // method with return
    public static int add(int a, int b) {
        return a + b;
    }

    // boolean method
    public static boolean isAdult(int age) {
        return age >= 18;
    }

    // overloading
    public static int add(int a, int b, int c) {
        return a + b + c;
    }

    public static void main(String[] args) {
        sayHello();
        greet(""Thabo"");

        int answer = add(10, 5);
        System.out.println(answer);   // 15

        if (isAdult(20)) {
            System.out.println(""Adult"");
        }
    }
}"
                }
            );
            context.SaveChanges();

            // ============ QUIZZES ============
            context.Quizzes.AddOrUpdate(q => q.Id,
                new Quiz { Id = 1, LessonId = 1, Title = "Quiz: What is Programming?", IsFinalTest = false },
                new Quiz { Id = 2, LessonId = 2, Title = "Quiz: Variables and Data Types", IsFinalTest = false },
                new Quiz { Id = 3, LessonId = 3, Title = "Quiz: If Statements", IsFinalTest = false },
                new Quiz { Id = 4, LessonId = 4, Title = "Quiz: Loops", IsFinalTest = false },
                new Quiz { Id = 5, LessonId = 5, Title = "Quiz: Functions", IsFinalTest = false },
                new Quiz { Id = 6, LessonId = 6, Title = "Quiz: Introduction to Java", IsFinalTest = false },
                new Quiz { Id = 7, LessonId = 7, Title = "Quiz: Java Variables and Types", IsFinalTest = false },
                new Quiz { Id = 8, LessonId = 8, Title = "Quiz: Java If Statements", IsFinalTest = false },
                new Quiz { Id = 9, LessonId = 9, Title = "Quiz: Java Loops", IsFinalTest = false },
                new Quiz { Id = 10, LessonId = 10, Title = "Quiz: Java Methods", IsFinalTest = false },
                new Quiz { Id = 11, CourseId = 1, Title = "Final Test: Python", IsFinalTest = true },
                new Quiz { Id = 12, CourseId = 2, Title = "Final Test: Java", IsFinalTest = true }
            );
            context.SaveChanges();

            // ============ QUESTIONS ============
            context.Questions.AddOrUpdate(q => q.Id,
                // ---- Quiz 1 (Python: What is Programming?) ----
                new Question
                {
                    Id = 1,
                    QuizId = 1,
                    OrderIndex = 1,
                    QuestionText = "What does print() do in Python?",
                    OptionA = "Reads user input",
                    OptionB = "Displays something on the screen",
                    OptionC = "Deletes a file",
                    OptionD = "Starts a loop",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 2,
                    QuizId = 1,
                    OrderIndex = 2,
                    QuestionText = "What is a string?",
                    OptionA = "A number",
                    OptionB = "A type of loop",
                    OptionC = "Text",
                    OptionD = "A file",
                    CorrectOption = "C"
                },
                new Question
                {
                    Id = 3,
                    QuizId = 1,
                    OrderIndex = 3,
                    QuestionText = "What does input() always return?",
                    OptionA = "An integer",
                    OptionB = "A boolean",
                    OptionC = "Text (string)",
                    OptionD = "A float",
                    CorrectOption = "C"
                },
                new Question
                {
                    Id = 4,
                    QuizId = 1,
                    OrderIndex = 4,
                    QuestionText = "How do you write a comment in Python?",
                    OptionA = "// comment",
                    OptionB = "/* comment */",
                    OptionC = "# comment",
                    OptionD = "-- comment",
                    CorrectOption = "C"
                },

                // ---- Quiz 2 (Python: Variables) ----
                new Question
                {
                    Id = 5,
                    QuizId = 2,
                    OrderIndex = 1,
                    QuestionText = "What type is 20.5?",
                    OptionA = "int",
                    OptionB = "float",
                    OptionC = "str",
                    OptionD = "bool",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 6,
                    QuizId = 2,
                    OrderIndex = 2,
                    QuestionText = "What does type() do?",
                    OptionA = "Changes the type",
                    OptionB = "Prints a value",
                    OptionC = "Returns the data type of a value",
                    OptionD = "Converts to string",
                    CorrectOption = "C"
                },
                new Question
                {
                    Id = 7,
                    QuizId = 2,
                    OrderIndex = 3,
                    QuestionText = "What is 10 % 3?",
                    OptionA = "3",
                    OptionB = "1",
                    OptionC = "0",
                    OptionD = "10",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 8,
                    QuizId = 2,
                    OrderIndex = 4,
                    QuestionText = "Which is TRUE in Python?",
                    OptionA = "true",
                    OptionB = "TRUE",
                    OptionC = "True",
                    OptionD = "Yes",
                    CorrectOption = "C"
                },

                // ---- Quiz 3 (Python: If Statements) ----
                new Question
                {
                    Id = 9,
                    QuizId = 3,
                    OrderIndex = 1,
                    QuestionText = "What does indentation mean in Python?",
                    OptionA = "It's optional",
                    OptionB = "It shows which code belongs to the if block",
                    OptionC = "It changes the variable",
                    OptionD = "It's for comments",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 10,
                    QuizId = 3,
                    OrderIndex = 2,
                    QuestionText = "What does == mean?",
                    OptionA = "Assignment",
                    OptionB = "Comparison (equal to)",
                    OptionC = "Addition",
                    OptionD = "None",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 11,
                    QuizId = 3,
                    OrderIndex = 3,
                    QuestionText = "Which is the correct Python AND operator?",
                    OptionA = "&&",
                    OptionB = "&",
                    OptionC = "and",
                    OptionD = "AND",
                    CorrectOption = "C"
                },
                new Question
                {
                    Id = 12,
                    QuizId = 3,
                    OrderIndex = 4,
                    QuestionText = "What runs if the if condition is False?",
                    OptionA = "The if block",
                    OptionB = "The else block",
                    OptionC = "Nothing",
                    OptionD = "An error occurs",
                    CorrectOption = "B"
                },

                // ---- Quiz 4 (Python: Loops) ----
                new Question
                {
                    Id = 13,
                    QuizId = 4,
                    OrderIndex = 1,
                    QuestionText = "What does range(5) produce?",
                    OptionA = "1,2,3,4,5",
                    OptionB = "0,1,2,3,4",
                    OptionC = "0,1,2,3,4,5",
                    OptionD = "5",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 14,
                    QuizId = 4,
                    OrderIndex = 2,
                    QuestionText = "What causes an infinite loop?",
                    OptionA = "Using break",
                    OptionB = "Using continue",
                    OptionC = "Never updating the loop variable",
                    OptionD = "Using range()",
                    CorrectOption = "C"
                },
                new Question
                {
                    Id = 15,
                    QuizId = 4,
                    OrderIndex = 3,
                    QuestionText = "What does break do?",
                    OptionA = "Skips one iteration",
                    OptionB = "Exits the loop entirely",
                    OptionC = "Restarts the loop",
                    OptionD = "Causes an error",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 16,
                    QuizId = 4,
                    OrderIndex = 4,
                    QuestionText = "What does continue do?",
                    OptionA = "Skips the current iteration",
                    OptionB = "Ends the loop",
                    OptionC = "Prints the value",
                    OptionD = "Nothing",
                    CorrectOption = "A"
                },

                // ---- Quiz 5 (Python: Functions) ----
                new Question
                {
                    Id = 17,
                    QuizId = 5,
                    OrderIndex = 1,
                    QuestionText = "What is a function?",
                    OptionA = "A variable",
                    OptionB = "A reusable block of code",
                    OptionC = "A loop",
                    OptionD = "A string",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 18,
                    QuizId = 5,
                    OrderIndex = 2,
                    QuestionText = "Difference between print and return?",
                    OptionA = "No difference",
                    OptionB = "print displays, return sends a value back",
                    OptionC = "print returns, return displays",
                    OptionD = "Both return",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 19,
                    QuizId = 5,
                    OrderIndex = 3,
                    QuestionText = "What is a parameter?",
                    OptionA = "A value passed to a function",
                    OptionB = "A variable in the function definition",
                    OptionC = "A loop counter",
                    OptionD = "A comment",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 20,
                    QuizId = 5,
                    OrderIndex = 4,
                    QuestionText = "What does a function return by default (no return statement)?",
                    OptionA = "0",
                    OptionB = "True",
                    OptionC = "None",
                    OptionD = "An error",
                    CorrectOption = "C"
                },

                // ---- Quiz 6 (Java: Intro) ----
                new Question
                {
                    Id = 21,
                    QuizId = 6,
                    OrderIndex = 1,
                    QuestionText = "Every Java program must have a class and a ___ method.",
                    OptionA = "start",
                    OptionB = "run",
                    OptionC = "main",
                    OptionD = "init",
                    CorrectOption = "C"
                },
                new Question
                {
                    Id = 22,
                    QuizId = 6,
                    OrderIndex = 2,
                    QuestionText = "What does System.out.println() do?",
                    OptionA = "Reads input",
                    OptionB = "Prints and moves to a new line",
                    OptionC = "Prints on the same line",
                    OptionD = "Clears the screen",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 23,
                    QuizId = 6,
                    OrderIndex = 3,
                    QuestionText = "Which class is used to read user input in Java?",
                    OptionA = "Reader",
                    OptionB = "Input",
                    OptionC = "Scanner",
                    OptionD = "Console",
                    CorrectOption = "C"
                },
                new Question
                {
                    Id = 24,
                    QuizId = 6,
                    OrderIndex = 4,
                    QuestionText = "Difference between print() and println()?",
                    OptionA = "No difference",
                    OptionB = "println() moves to the next line",
                    OptionC = "print() is faster",
                    OptionD = "println() only prints numbers",
                    CorrectOption = "B"
                },

                // ---- Quiz 7 (Java: Variables) ----
                new Question
                {
                    Id = 25,
                    QuizId = 7,
                    OrderIndex = 1,
                    QuestionText = "Which type stores whole numbers?",
                    OptionA = "double",
                    OptionB = "String",
                    OptionC = "int",
                    OptionD = "boolean",
                    CorrectOption = "C"
                },
                new Question
                {
                    Id = 26,
                    QuizId = 7,
                    OrderIndex = 2,
                    QuestionText = "What is 5 / 2 in Java (both are ints)?",
                    OptionA = "2.5",
                    OptionB = "2",
                    OptionC = "3",
                    OptionD = "0",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 27,
                    QuizId = 7,
                    OrderIndex = 3,
                    QuestionText = "How do you write a boolean literal in Java?",
                    OptionA = "True",
                    OptionB = "TRUE",
                    OptionC = "true",
                    OptionD = "yes",
                    CorrectOption = "C"
                },
                new Question
                {
                    Id = 28,
                    QuizId = 7,
                    OrderIndex = 4,
                    QuestionText = "What does (int) 10.99 give?",
                    OptionA = "11",
                    OptionB = "10",
                    OptionC = "10.99",
                    OptionD = "0",
                    CorrectOption = "B"
                },

                // ---- Quiz 8 (Java: If) ----
                new Question
                {
                    Id = 29,
                    QuizId = 8,
                    OrderIndex = 1,
                    QuestionText = "Which operator compares two values in Java?",
                    OptionA = "=",
                    OptionB = "==",
                    OptionC = "=>",
                    OptionD = "<>",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 30,
                    QuizId = 8,
                    OrderIndex = 2,
                    QuestionText = "Java's AND operator is:",
                    OptionA = "and",
                    OptionB = "&",
                    OptionC = "&&",
                    OptionD = "AND",
                    CorrectOption = "C"
                },
                new Question
                {
                    Id = 31,
                    QuizId = 8,
                    OrderIndex = 3,
                    QuestionText = "How do you compare two Strings in Java?",
                    OptionA = "==",
                    OptionB = ".equals()",
                    OptionC = "equals()",
                    OptionD = ".compare()",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 32,
                    QuizId = 8,
                    OrderIndex = 4,
                    QuestionText = "What does the else branch run?",
                    OptionA = "When if is true",
                    OptionB = "When if is false",
                    OptionC = "Always",
                    OptionD = "Never",
                    CorrectOption = "B"
                },

                // ---- Quiz 9 (Java: Loops) ----
                new Question
                {
                    Id = 33,
                    QuizId = 9,
                    OrderIndex = 1,
                    QuestionText = "A for loop has three parts: start, condition, and ___",
                    OptionA = "break",
                    OptionB = "end",
                    OptionC = "update",
                    OptionD = "value",
                    CorrectOption = "C"
                },
                new Question
                {
                    Id = 34,
                    QuizId = 9,
                    OrderIndex = 2,
                    QuestionText = "The do-while loop runs at least ___ time(s).",
                    OptionA = "0",
                    OptionB = "1",
                    OptionC = "2",
                    OptionD = "5",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 35,
                    QuizId = 9,
                    OrderIndex = 3,
                    QuestionText = "What does break do?",
                    OptionA = "Skips one iteration",
                    OptionB = "Exits the loop",
                    OptionC = "Restarts",
                    OptionD = "Errors",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 36,
                    QuizId = 9,
                    OrderIndex = 4,
                    QuestionText = "What does continue do?",
                    OptionA = "Exits the loop",
                    OptionB = "Skips current iteration",
                    OptionC = "Restarts",
                    OptionD = "Nothing",
                    CorrectOption = "B"
                },

                // ---- Quiz 10 (Java: Methods) ----
                new Question
                {
                    Id = 37,
                    QuizId = 10,
                    OrderIndex = 1,
                    QuestionText = "In Java, functions are called:",
                    OptionA = "Functions",
                    OptionB = "Methods",
                    OptionC = "Blocks",
                    OptionD = "Procedures",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 38,
                    QuizId = 10,
                    OrderIndex = 2,
                    QuestionText = "What does void mean?",
                    OptionA = "Returns 0",
                    OptionB = "Returns nothing",
                    OptionC = "Returns null",
                    OptionD = "Empty parameter",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 39,
                    QuizId = 10,
                    OrderIndex = 3,
                    QuestionText = "A method with return type int must:",
                    OptionA = "Print a value",
                    OptionB = "Return an int",
                    OptionC = "Be called from main",
                    OptionD = "Take no parameters",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 40,
                    QuizId = 10,
                    OrderIndex = 4,
                    QuestionText = "Two methods with the same name but different parameters is called:",
                    OptionA = "Overriding",
                    OptionB = "Overloading",
                    OptionC = "Duplicating",
                    OptionD = "Casting",
                    CorrectOption = "B"
                },

                // ---- Python Final Test ----
                new Question
                {
                    Id = 41,
                    QuizId = 11,
                    OrderIndex = 1,
                    QuestionText = "Which is the correct way to comment in Python?",
                    OptionA = "// comment",
                    OptionB = "# comment",
                    OptionC = "/* comment */",
                    OptionD = "<!-- comment -->",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 42,
                    QuizId = 11,
                    OrderIndex = 2,
                    QuestionText = "What is the result of 7 // 2 in Python?",
                    OptionA = "3.5",
                    OptionB = "3",
                    OptionC = "4",
                    OptionD = "1",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 43,
                    QuizId = 11,
                    OrderIndex = 3,
                    QuestionText = "What does input() return by default?",
                    OptionA = "int",
                    OptionB = "float",
                    OptionC = "str",
                    OptionD = "bool",
                    CorrectOption = "C"
                },
                new Question
                {
                    Id = 44,
                    QuizId = 11,
                    OrderIndex = 4,
                    QuestionText = "Which is used to repeat code in Python?",
                    OptionA = "if",
                    OptionB = "for",
                    OptionC = "def",
                    OptionD = "print",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 45,
                    QuizId = 11,
                    OrderIndex = 5,
                    QuestionText = "What does range(1, 5) produce?",
                    OptionA = "1,2,3,4,5",
                    OptionB = "1,2,3,4",
                    OptionC = "0,1,2,3,4",
                    OptionD = "2,3,4,5",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 46,
                    QuizId = 11,
                    OrderIndex = 6,
                    QuestionText = "Which keyword returns a value from a function?",
                    OptionA = "print",
                    OptionB = "return",
                    OptionC = "output",
                    OptionD = "yield",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 47,
                    QuizId = 11,
                    OrderIndex = 7,
                    QuestionText = "In Python, indentation is:",
                    OptionA = "Optional",
                    OptionB = "Required - it defines code blocks",
                    OptionC = "Only for comments",
                    OptionD = "Only for loops",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 48,
                    QuizId = 11,
                    OrderIndex = 8,
                    QuestionText = "What type is the value True in Python?",
                    OptionA = "int",
                    OptionB = "str",
                    OptionC = "bool",
                    OptionD = "float",
                    CorrectOption = "C"
                },

                // ---- Java Final Test ----
                new Question
                {
                    Id = 49,
                    QuizId = 12,
                    OrderIndex = 1,
                    QuestionText = "Which method is the entry point of a Java program?",
                    OptionA = "start()",
                    OptionB = "run()",
                    OptionC = "main()",
                    OptionD = "init()",
                    CorrectOption = "C"
                },
                new Question
                {
                    Id = 50,
                    QuizId = 12,
                    OrderIndex = 2,
                    QuestionText = "What is 9 / 2 in Java when both are int?",
                    OptionA = "4.5",
                    OptionB = "5",
                    OptionC = "4",
                    OptionD = "0",
                    CorrectOption = "C"
                },
                new Question
                {
                    Id = 51,
                    QuizId = 12,
                    OrderIndex = 3,
                    QuestionText = "Which type would you use for the value true?",
                    OptionA = "int",
                    OptionB = "boolean",
                    OptionC = "String",
                    OptionD = "char",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 52,
                    QuizId = 12,
                    OrderIndex = 4,
                    QuestionText = "What does Scanner.nextInt() read?",
                    OptionA = "A whole number",
                    OptionB = "A word",
                    OptionC = "A line of text",
                    OptionD = "A decimal",
                    CorrectOption = "A"
                },
                new Question
                {
                    Id = 53,
                    QuizId = 12,
                    OrderIndex = 5,
                    QuestionText = "Java's OR operator is:",
                    OptionA = "or",
                    OptionB = "|",
                    OptionC = "||",
                    OptionD = "OR",
                    CorrectOption = "C"
                },
                new Question
                {
                    Id = 54,
                    QuizId = 12,
                    OrderIndex = 6,
                    QuestionText = "How do you compare Strings in Java?",
                    OptionA = "==",
                    OptionB = ".equals()",
                    OptionC = ".same()",
                    OptionD = "compare()",
                    CorrectOption = "B"
                },
                new Question
                {
                    Id = 55,
                    QuizId = 12,
                    OrderIndex = 7,
                    QuestionText = "A method with return type void means it:",
                    OptionA = "Returns 0",
                    OptionB = "Returns null",
                    OptionC = "Returns nothing",
                    OptionD = "Returns a String",
                    CorrectOption = "C"
                },
                new Question
                {
                    Id = 56,
                    QuizId = 12,
                    OrderIndex = 8,
                    QuestionText = "Which loop runs at least once?",
                    OptionA = "for",
                    OptionB = "while",
                    OptionC = "do-while",
                    OptionD = "for-each",
                    CorrectOption = "C"
                }
            );
            context.SaveChanges();

            // ============ KEEP YOUR EMAIL AS ADMIN ============
            context.Database.ExecuteSqlCommand("UPDATE Users SET IsAdmin = 1 WHERE Email = '224144451@stu.ukzn.ac.za'");
            context.Database.ExecuteSqlCommand("UPDATE Users SET IsEmailConfirmed = 1 WHERE IsEmailConfirmed = 0");
        }
    }
}