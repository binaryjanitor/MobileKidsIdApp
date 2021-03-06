﻿using System;
using System.Collections.Generic;
using MobileKidsIdApp.Models;

namespace MobileKidsIdApp.Services
{
    public partial class FamilyRepository
    {
        private Lazy<List<Child>> _childCache;

        public List<Child> Children => _childCache.Value;
        public Child CurrentChild { get; private set; }

        public void SetCurrentChild(Child child) => CurrentChild = child;
        public void ClearCurrentChild() => CurrentChild = null;
        public bool HasCurrentChild => CurrentChild != null;

        public Child NewChild()
        {
            var child = new Child();
            Children.Add(child);
            return child;
        }

        public void RemoveChild(Child child)
        {
            Children.Remove(child);
            SaveChildren();
        }

        public void SaveChildren() => StoreChildren();
    }
}
