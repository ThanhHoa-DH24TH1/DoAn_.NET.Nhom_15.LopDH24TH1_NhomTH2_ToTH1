using ClosedXML.Excel;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyKTX.Helpers
{
    public static class ExcelHelper
    {
        /// <summary>
        /// Xuất dữ liệu từ DataGridView ra file Excel (.xlsx)
        /// </summary>
        /// <param name="dgv">DataGridView chứa dữ liệu</param>
        /// <param name="sheetName">Tên của Sheet trong Excel</param>
        /// <param name="fileNamePrefix">Tên file mặc định (ví dụ: DanhSachSinhVien)</param>
        public static void ExportToExcel(DataGridView dgv, string sheetName, string fileNamePrefix)
        {
            // 1. Kiểm tra dữ liệu
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Mở hộp thoại chọn nơi lưu file
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.Title = "Xuất dữ liệu ra Excel";
                sfd.FileName = $"{fileNamePrefix}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"; // Tên file kèm ngày giờ

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 3. Tạo Workbook và Worksheet
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add(sheetName);

                            // 4. Xuất Tiêu Đề Cột (Header)
                            int colIndex = 1;
                            for (int i = 0; i < dgv.Columns.Count; i++)
                            {
                                // Chỉ xuất các cột ĐANG HIỆN (Visible)
                                if (dgv.Columns[i].Visible)
                                {
                                    worksheet.Cell(1, colIndex).Value = dgv.Columns[i].HeaderText;

                                    // Tô đậm và tô màu nền cho tiêu đề
                                    worksheet.Cell(1, colIndex).Style.Font.Bold = true;
                                    worksheet.Cell(1, colIndex).Style.Fill.BackgroundColor = XLColor.CornflowerBlue;
                                    worksheet.Cell(1, colIndex).Style.Font.FontColor = XLColor.White;

                                    colIndex++;
                                }
                            }

                            // 5. Xuất Dữ Liệu (Rows)
                            for (int i = 0; i < dgv.Rows.Count; i++)
                            {
                                colIndex = 1;
                                for (int j = 0; j < dgv.Columns.Count; j++)
                                {
                                    if (dgv.Columns[j].Visible)
                                    {
                                        // Lấy giá trị
                                        object cellValue = dgv.Rows[i].Cells[j].Value;

                                        // Xử lý giá trị null
                                        string valueStr = cellValue == null ? "" : cellValue.ToString();

                                        // Gán vào Excel (dòng i+2 vì dòng 1 là Header)
                                        worksheet.Cell(i + 2, colIndex).Value = valueStr;
                                        colIndex++;
                                    }
                                }
                            }

                            // 6. Tự động chỉnh độ rộng cột (AutoFit)
                            worksheet.Columns().AdjustToContents();

                            // 7. Lưu file
                            workbook.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("Xuất Excel thành công!\nĐường dẫn: " + sfd.FileName, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}