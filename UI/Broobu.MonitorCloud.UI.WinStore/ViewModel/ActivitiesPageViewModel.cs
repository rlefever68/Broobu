using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DevExpress.Core;

namespace Broobu.MonitorCloud.UI.WinStore.ViewModel
{
    /// <summary>
    /// A View Model for the GridPage.
    /// </summary>
    abstract public class BusinessEntity
    {
        [Display(Order = 0)]
        public string Name { get; set; }
        [Display(Order = 100)]
        public DateTime Date { get; set; }
        public BusinessEntity(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }
    }
    public class Activity : BusinessEntity
    {
        public Activity(string name, DateTime date)
            : base(name, date)
        {
        }
    }
    public class Invoice : BusinessEntity
    {
        public Invoice(string name, double amount, DateTime date)
            : base(name, date)
        {
            Amount = amount;
        }
        [Display(Order = 10)]
        public double Amount { get; set; }
    }
    public class Event : BusinessEntity
    {
        public Event(string name, DateTime date)
            : base(name, date)
        {
        }
    }
    public class EntityCollection<T> : List<T> where T : BusinessEntity
    {
        public EntityCollection(string name)
            : base()
        {
            Name = name;
        }
        public string Name { get; set; }
        public ICollection<T> Recent
        {
            get
            {
                return this.Skip(Math.Max(0, Count - 3)).Take(3).ToList<T>();
            }
        }
    }
    /// <summary>
    /// A View Model for the GridPage.
    /// </summary>
    public class ActivitiesPageViewModel : BindableBase, ISupportSaveLoadState
    {
        static EntityCollection<Activity> activities;
        static EntityCollection<Event> events;
        static EntityCollection<Invoice> invoices;
        static ActivitiesPageViewModel()
        {
            activities = new EntityCollection<Activity>("Activities") {
                new Activity("Activity 1", new DateTime(2012, 12, 1)),
                new Activity("Lorem ipsum dolor sit met, consectetur adipiscing elit. Maecenas tincidunt laoreet nisi, eget elementum turpis pulvinar nec.", new DateTime(2012, 10, 17)),
                new Activity("Etiam ante dolor, posuere id tempus non, viverra ut eros.", new DateTime(2012, 10, 1)),
                new Activity("Curabitur sollicitudin pretium dolor vitae ullamcorper. Suspendisse tempus varius libero ut interdum.", new DateTime(2012, 8, 5))
            };
            events = new EntityCollection<Event>("Events") {
                new Event("Christmas to New Year Clearance Sale", new DateTime(2012, 11, 1)),
                new Event("Autumn Sales", new DateTime(2012, 8, 12)),
                new Event("End-of-Season Clearance", new DateTime(2012, 2, 10)),
                new Event("DevX Carbon Deck Special Edition", new DateTime(2012, 1, 1)),
                new Event("30% off Everything Only Today", new DateTime(2012, 1, 8))
            };
            invoices = new EntityCollection<Invoice>("Invoices") {
                new Invoice("Cash Withdrawal", 827.5, new DateTime(2012, 11, 3)),
                new Invoice("Company Paycheck", 357.5, new DateTime(2012, 10, 3)),
                new Invoice("ATM WITHDRAWAL", 2057.5, new DateTime(2012, 9, 3)),
                new Invoice("American Express", 2007.5, new DateTime(2012, 6, 3)),
                new Invoice("Check #305", 2007.5, new DateTime(2012, 5, 3)),
                new Invoice("Check #305", 1908.0, new DateTime(2012, 4, 3)),
                new Invoice("Check #305", 2807.5, new DateTime(2012, 5, 3)),
                new Invoice("Company Paycheck", 757.5, new DateTime(2012, 10, 3)),
                new Invoice("American Express", 2907.5, new DateTime(2012, 6, 3)),
                new Invoice("Cash Withdrawal", 327.2, new DateTime(2012, 11, 3)),
                new Invoice("American Express", 2887.5, new DateTime(2012, 6, 3)),
                new Invoice("Company Paycheck", 757.5, new DateTime(2012, 10, 3)),
                new Invoice("ATM WITHDRAWAL", 1058.0, new DateTime(2012, 9, 3))
            };
        }
        public EntityCollection<Activity> Activities { get { return activities; } }
        public EntityCollection<Event> Events { get { return events; } }
        public EntityCollection<Invoice> Invoices { get { return invoices; } }
        public object DataSource { get; private set; }
        public void LoadState(object navigationParameter, PageStateStorage pageState)
        {
            DataSource = navigationParameter;
        }
        public void SaveState(PageStateStorage pageState)
        {
        }
    }
}
