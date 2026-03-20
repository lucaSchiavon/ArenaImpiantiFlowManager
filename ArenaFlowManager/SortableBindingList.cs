using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFlowManager
{
    public class SortableBindingList<T> : BindingList<T>
    {
        public SortableBindingList() : base() { }

        public SortableBindingList(IList<T> list) : base(list) { }

        private bool isSorted;
        private ListSortDirection sortDirection;
        private PropertyDescriptor sortProperty;

        protected override bool SupportsSortingCore => true;
        protected override bool IsSortedCore => isSorted;

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            var items = (List<T>)this.Items;

            items.Sort((x, y) =>
            {
                var xValue = prop.GetValue(x);
                var yValue = prop.GetValue(y);
                return Comparer<object>.Default.Compare(xValue, yValue);
            });

            sortDirection = direction;
            sortProperty = prop;
            isSorted = true;

            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
    }


}
