using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Bosphorus.Assemble.BootStrapper.Runner.Demo.ExecutableItem;

namespace Bosphorus.Assemble.BootStrapper.Runner.Demo
{
    public partial class ExecuterHostForm : Form
    {
        public ExecuterHostForm(IList<IExecutionItemList> executionItemListList)
        {
            InitializeComponent();

            IEnumerable<TreeNode> treeNodes = from executionItemList in executionItemListList
                            orderby executionItemList.ToString()
                            select BuildTreeNode(executionItemList);
                            

            tvExecutionList.Nodes.AddRange(treeNodes.ToArray());
        }

        private TreeNode BuildTreeNode(IExecutionItemList executionItemList)
        {
            IEnumerable<TreeNode> treeNodes = from executionItem in executionItemList.Items
                            select BuildTreeNode(executionItem);

            TreeNode node = new TreeNode(executionItemList.ToString(), treeNodes.ToArray());
            return node;
        }

        private TreeNode BuildTreeNode(IExecutableItem executableItem)
        {
            TreeNode node = new TreeNode(executableItem.ToString());
            node.Tag = executableItem;
            return node;
        }

        private void Execute(IExecutableItem executableItem)
        {
            if (executableItem == null)
                return;

            Cursor current = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            tbConsole.Clear();
            tbConsole.Refresh();
            System.Console.Clear();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            IList data = executableItem.Execute();
            stopWatch.Stop();



            //bindingSource.DataSource = data;
            //bindingSource.CurrencyManager.Refresh();
            //dataGrid1.ParentRowsVisible = true;
            //dataGrid1.AllowNavigation = true;
            //dataGrid1.Text = executableItem.ToString();
            //dataGrid1.DataSource = data;
            //dataGrid1.SetDataBinding(data, null);
            //dataGrid1.
            dgResult.Text = executableItem.ToString();
            dgResult.DataSource = data;
            dgResult.CellFormatting += DgResultOnCellFormatting;

            int count = data?.Count ?? 0;
            double totalSeconds = stopWatch.Elapsed.TotalSeconds;
            int countPerSecond = (int)(count / totalSeconds);
            this.Text = $"[{executableItem}] -> Count: {count}, Time: {totalSeconds}, CountPerSecond: {countPerSecond}";

            Cursor.Current = current;
        }

        private void DgResultOnCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            DataGridView grid = (DataGridView)sender;
            DataGridViewColumn column = grid.Columns[columnIndex];
            Type columnValueType = column.ValueType;
            if (columnValueType == typeof(string))
                return;

            if (columnValueType.IsValueType)
                return;

            e.Value = "[??]";
        }

        private void tvExecutionList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode treeNode = e.Node;
            IExecutableItem executableItem = (IExecutableItem) treeNode.Tag;
            Execute(executableItem);
        }
    }
}