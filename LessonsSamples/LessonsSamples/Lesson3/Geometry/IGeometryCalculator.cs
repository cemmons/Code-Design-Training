﻿using System;

namespace LessonsSamples.Lesson3.Geometry
{
    class Geometry : IGeometryCalculator
    {
        private readonly IGeometryCalculatorFactory factory = new GeometryCalculatorFactory();

        public double GetArea(object shape)
        {
            IGeometryCalculator calculator = GetCalculator(shape.GetType());
            return calculator.GetArea(shape);
        }

        private IGeometryCalculator GetCalculator(Type shape)
        {
            return factory.GetCalculator(shape);
        }
    }

    interface IGeometryCalculator
    {
        double GetArea(object shape);
    }

    interface IGeometryCalculator<T> : IGeometryCalculator
    {
        double GetArea(T shape);
    }

    abstract class GeometryCalculator<T> : IGeometryCalculator<T>
    {
        public abstract double GetArea(T shape);

        public double GetArea(object shape)
        {
            return GetArea((T) shape);
        }
    }
}