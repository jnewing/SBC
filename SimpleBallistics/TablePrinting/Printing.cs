using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleBallistics.TablePrinting
{
    class Printing
    {

        /// <summary>
        /// Our grid row string format.
        /// </summary>
        StringFormat strFormat;

        /// <summary>
        /// Left coords of columns.
        /// </summary>
        ArrayList arrColumnLefts = new ArrayList();

        /// <summary>
        /// Column widths.
        /// </summary>
        ArrayList arrColumnWidths = new ArrayList();

        /// <summary>
        /// Get / sets the grid view cell height.
        /// </summary>
        int iCellHeight = 0;

        /// <summary>
        /// Total width.
        /// </summary>
        int iTotalWidth = 0;

        /// <summary>
        /// Row counter.
        /// </summary>
        int iRow = 0;

        /// <summary>
        /// First page check (headers)
        /// </summary>
        bool bFirstPage = false;

        /// <summary>
        /// New page check (headers)
        /// </summary>
        bool bNewPage = false;

        /// <summary>
        /// Height of header
        /// </summary>
        int iHeaderHeight = 0;

        /// <summary>
        /// Holds the users slection (if anything is selected)
        /// </summary>
        List<int> _selection = null;

        /// <summary>
        /// Holds our datagrid with the data we are going to print.
        /// </summary>
        DataGridView _dataGrid = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <param name="selected"></param>
        /// <param name="cellHeight"></param>
        /// <param name="headerHeight"></param>
        public Printing(DataGridView dataGrid, List<int> selected = null, int cellHeight = 0, int headerHeight = 0)
        {
            // set our datagrid (our print data)
            _dataGrid = dataGrid;
                
            // if we have any print selections
            _selection = selected;

            // options
            iCellHeight = cellHeight;
            iHeaderHeight = headerHeight;

            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                // calculating total width
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in _dataGrid.Columns)
                {
                    if (dgvGridCol.Visible)
                        iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Print the page.
        /// </summary>
        /// <param name="_e"></param>
        public void printPage(PrintPageEventArgs _e)
        {
            try
            {
                // set the left margin
                int iLeftMargin = _e.MarginBounds.Left;

                // set the top margin
                int iTopMargin = _e.MarginBounds.Top;

                // more pages?
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                // first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in _dataGrid.Columns)
                    {
                        if (GridCol.Visible)
                        {

                            iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width / (double)iTotalWidth * (double)iTotalWidth * ((double)_e.MarginBounds.Width / (double)iTotalWidth))));
                            iHeaderHeight = (int)(_e.Graphics.MeasureString(GridCol.HeaderText, GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                            // save width and height of headres
                            arrColumnLefts.Add(iLeftMargin);
                            arrColumnWidths.Add(iTmpWidth);
                            iLeftMargin += iTmpWidth;
                        }

                    }
                }

                while (iRow <= _dataGrid.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = _dataGrid.Rows[iRow];

                    // if we have a selection set we are only going to print the selected 
                    if (_selection != null)
                    {
                        if (!_selection.Contains(iRow))
                        {
                            iRow++;
                            continue;
                        }
                    }
                    
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;

                    if (iTopMargin + iCellHeight >= _e.MarginBounds.Height + _e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            // header
                            _e.Graphics.DrawString("Range Table", new Font(_dataGrid.Font, FontStyle.Bold), Brushes.Black, _e.MarginBounds.Left, _e.MarginBounds.Top - _e.Graphics.MeasureString("Customer Summary", new Font(_dataGrid.Font, FontStyle.Bold), _e.MarginBounds.Width).Height - 13);

                            // date
                            //String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //_e.Graphics.DrawString(strDate, new Font(_dataGrid.Font, FontStyle.Bold), Brushes.Black, _e.MarginBounds.Left + (_e.MarginBounds.Width - _e.Graphics.MeasureString(strDate, new Font(_dataGrid.Font, FontStyle.Bold), _e.MarginBounds.Width).Width), _e.MarginBounds.Top - _e.Graphics.MeasureString("Customer Summary", new Font(new Font(_dataGrid.Font, FontStyle.Bold), FontStyle.Bold), _e.MarginBounds.Width).Height - 13);

                            // columns            
                            iTopMargin = _e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in _dataGrid.Columns)
                            {
                                if (GridCol.Visible)
                                {
                                    _e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), new Rectangle((int)arrColumnLefts[iCount], iTopMargin, (int)arrColumnWidths[iCount], iHeaderHeight));
                                    _e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount], iTopMargin, (int)arrColumnWidths[iCount], iHeaderHeight));
                                    _e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font, new SolidBrush(GridCol.InheritedStyle.ForeColor), new RectangleF((int)arrColumnLefts[iCount], iTopMargin, (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);

                                    iCount++;
                                }
                            }

                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }

                        iCount = 0;
                        
                        // columns contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.OwningColumn.Visible)
                            {
                                if (Cel.Value != null)
                                {
                                    _e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font, new SolidBrush(Cel.InheritedStyle.ForeColor), new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin, (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                                }

                                // cell borders
                                _e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount], iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                                iCount++;
                            }
                        }
                    }

                    iRow++;
                    iTopMargin += iCellHeight;
                }

                // print another page.
                if (bMorePagesToPrint)
                    _e.HasMorePages = true;
                else
                    _e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
