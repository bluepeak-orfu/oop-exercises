using System;
using OOArvExercises;

//// Exercise: Arv - 2
//MyDerivedClass1 d1 = new MyDerivedClass1();
//d1.BaseAdd();

//// Exercise: Arv - 3
//MyDerivedClass2 d2 = new MyDerivedClass2(100.0);
//d2.BaseAdd();


//// Exercise: variabler och casting - 1
//MyBaseClass x = new MyDerivedClass1();
//MyBaseClass y = new MyBaseClass(4);

//// Exercise: variabler och casting - 2
//x.BaseAdd();
//y.BaseAdd();

//// Exercise: variabler och casting - 3
////x.DerivedMessage();
////y.DerivedMessage();

//// Exercise: variabler och casting - 4
//MyDerivedClass1 dX;
//MyDerivedClass1 dY;

//dX = (MyDerivedClass1)x;
////dY = (MyDerivedClass1)y;

//// Exercise: variabler och casting - 5
//MyBaseClass[] myBaseClassArray = new MyBaseClass[3];
//myBaseClassArray[0] = new MyBaseClass(3);
//myBaseClassArray[1] = new MyDerivedClass1();
//myBaseClassArray[2] = new MyBaseClass(8);

//foreach (MyBaseClass item in myBaseClassArray)
//{
//    if (item.GetType() == typeof(MyDerivedClass1))
//    {
//        MyDerivedClass1 x = (MyDerivedClass1)item;
//        x.DerivedMessage();
//    }
//}

//foreach (MyBaseClass item in myBaseClassArray)
//{
//    if (item is MyDerivedClass1 x)
//    {
//        x.DerivedMessage();
//    }
//}
