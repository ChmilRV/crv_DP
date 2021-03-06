﻿using System;
using static System.Console;
/*https://refactoring.guru/ru/design-patterns/decorator
Декоратор — это структурный паттерн проектирования,
который позволяет динамически добавлять объектам новую функциональность,
оборачивая их в полезные «обёртки».*/
namespace DesignPatterns_Decorator
{
    public abstract class Component
    {
        public abstract string Operation();
    }
    class ConcreteComponent : Component
    {
        public override string Operation() { return "ConcreteComponent"; }
    }
    abstract class Decorator : Component
    {
        protected Component _component;
        public Decorator(Component component) { _component = component; }
        public void SetComponent(Component component) { _component = component; }
        public override string Operation()
        {
            if (_component != null) return _component.Operation();
            else return string.Empty;
        }
    }
    class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(Component comp) : base(comp) { }
        public override string Operation() { return $"ConcreteDecoratorA({base.Operation()})"; }
    }
    class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(Component comp) : base(comp) { }
        public override string Operation() { return $"ConcreteDecoratorB({base.Operation()})"; }
    }
    public class Client
    {
        public void ClientCode(Component component) { WriteLine("RESULT: " + component.Operation()); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            var simple = new ConcreteComponent();
            WriteLine("Client: I get a simple component:");
            client.ClientCode(simple);
            WriteLine();
            ConcreteDecoratorA decorator1 = new ConcreteDecoratorA(simple);
            ConcreteDecoratorB decorator2 = new ConcreteDecoratorB(decorator1);
            ConcreteDecoratorB decorator3 = new ConcreteDecoratorB(decorator2);
            ConcreteDecoratorB decorator4 = new ConcreteDecoratorB(decorator3);
            ConcreteDecoratorA decorator5 = new ConcreteDecoratorA(decorator4);
            WriteLine("Client: Now I've got a decorated component:");
            client.ClientCode(decorator2);
            client.ClientCode(decorator3);
            client.ClientCode(decorator4);
            client.ClientCode(decorator5);
            ReadKey();
        }
    }
}
