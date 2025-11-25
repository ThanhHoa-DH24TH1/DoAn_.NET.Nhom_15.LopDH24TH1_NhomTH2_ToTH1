CREATE DATABASE DormitoryDB;
GO

USE DormitoryDB;
GO

-- Bảng Users (Tài khoản đăng nhập)
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Role NVARCHAR(20) NOT NULL CHECK (Role IN ('Admin', 'Student')),
    CreatedDate DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);

-- Bảng Students (Sinh viên)
CREATE TABLE Students (
    StudentID INT PRIMARY KEY IDENTITY(1,1),
    StudentCode NVARCHAR(20) UNIQUE NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender NVARCHAR(10) CHECK (Gender IN (N'Nam', N'Nữ')),
    PhoneNumber NVARCHAR(15),
    Email NVARCHAR(100),
    IDCard NVARCHAR(20) UNIQUE NOT NULL,
    Address NVARCHAR(255),
    Faculty NVARCHAR(100),
    Major NVARCHAR(100),
    Class NVARCHAR(50),
    Status NVARCHAR(20) DEFAULT N'Đang ở',
    UserID INT,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- Bảng Rooms (Phòng)
CREATE TABLE Rooms (
    RoomID INT PRIMARY KEY IDENTITY(1,1),
    RoomNumber NVARCHAR(10) UNIQUE NOT NULL,
    Building NVARCHAR(10) NOT NULL,
    Floor INT NOT NULL,
    RoomType NVARCHAR(20) NOT NULL,
    Capacity INT NOT NULL,
    CurrentOccupancy INT DEFAULT 0,
    PricePerMonth DECIMAL(10,0) NOT NULL,
    Status NVARCHAR(20) DEFAULT N'Trống',
    Description NVARCHAR(255)
);

-- Bảng Contracts (Hợp đồng)
CREATE TABLE Contracts (
    ContractID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT NOT NULL,
    RoomID INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    MonthlyFee DECIMAL(10,0) NOT NULL,
    Deposit DECIMAL(10,0) NOT NULL,
    Status NVARCHAR(20) DEFAULT N'Đang hiệu lực',
    SignedDate DATE DEFAULT GETDATE(),
    Notes NVARCHAR(255),
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID)
);

-- Bảng Invoices (Hóa đơn)
CREATE TABLE Invoices (
    InvoiceID INT PRIMARY KEY IDENTITY(1,1),
    ContractID INT NOT NULL,
    StudentID INT NOT NULL,
    BillingMonth NVARCHAR(7) NOT NULL,
    RoomFee DECIMAL(10,0) NOT NULL,
    ElectricityFee DECIMAL(10,0) DEFAULT 0,
    WaterFee DECIMAL(10,0) DEFAULT 0,
    InternetFee DECIMAL(10,0) DEFAULT 0,
    ServiceFee DECIMAL(10,0) DEFAULT 0,
    TotalAmount DECIMAL(10,0) NOT NULL,
    PaidAmount DECIMAL(10,0) DEFAULT 0,
    RemainingAmount DECIMAL(10,0) NOT NULL,
    Status NVARCHAR(20) DEFAULT N'Chưa thanh toán',
    DueDate DATE,
    PaymentDate DATE,
    CreatedDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ContractID) REFERENCES Contracts(ContractID),
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
);

-- Bảng Payments (Lịch sử thanh toán)
CREATE TABLE Payments (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    InvoiceID INT NOT NULL,
    Amount DECIMAL(10,0) NOT NULL,
    PaymentMethod NVARCHAR(50),
    PaymentDate DATETIME DEFAULT GETDATE(),
    Notes NVARCHAR(255),
    FOREIGN KEY (InvoiceID) REFERENCES Invoices(InvoiceID)
);

-- Index để tăng tốc truy vấn
CREATE INDEX idx_student_code ON Students(StudentCode);
CREATE INDEX idx_room_number ON Rooms(RoomNumber);
CREATE INDEX idx_invoice_month ON Invoices(BillingMonth);
CREATE INDEX idx_contract_student ON Contracts(StudentID);

GO



USE DormitoryDB;
GO

-- Insert Users
INSERT INTO Users (Username, Password, FullName, Role) VALUES
('admin', 'e10adc3949ba59abbe56e057f20f883e', N'Quản trị viên', 'Admin'), -- pass: 123456
('sv2001', 'e10adc3949ba59abbe56e057f20f883e', N'Nguyễn Văn A', 'Student'),
('sv2002', 'e10adc3949ba59abbe56e057f20f883e', N'Trần Thị B', 'Student');

-- Insert Students
INSERT INTO Students (StudentCode, FullName, DateOfBirth, Gender, PhoneNumber, Email, IDCard, Address, Faculty, Major, Class, UserID) VALUES
('2001001', N'Nguyễn Văn A', '2002-01-15', N'Nam', '0901234567', 'a@email.com', '001002003004', N'Hà Nội', N'Công nghệ thông tin', N'CNTT', 'IT01', 2),
('2001002', N'Trần Thị B', '2002-03-20', N'Nữ', '0902345678', 'b@email.com', '001002003005', N'TP.HCM', N'Công nghệ thông tin', N'CNTT', 'IT01', 3),
('2001003', N'Lê Văn C', '2002-05-10', N'Nam', '0903456789', 'c@email.com', '001002003006', N'Đà Nẵng', N'Kinh tế', N'KT', 'EC01', NULL),
('2001004', N'Phạm Thị D', '2002-07-25', N'Nữ', '0904567890', 'd@email.com', '001002003007', N'Cần Thơ', N'Kinh tế', N'KT', 'EC01', NULL);

-- Insert Rooms
INSERT INTO Rooms (RoomNumber, Building, Floor, RoomType, Capacity, CurrentOccupancy, PricePerMonth, Status) VALUES
('A101', 'A', 1, N'4 người', 4, 2, 500000, N'Còn chỗ'),
('A102', 'A', 1, N'4 người', 4, 0, 500000, N'Trống'),
('A201', 'A', 2, N'6 người', 6, 0, 400000, N'Trống'),
('B101', 'B', 1, N'2 người', 2, 0, 800000, N'Trống'),
('B102', 'B', 1, N'4 người', 4, 0, 500000, N'Trống');

-- Insert Contracts
INSERT INTO Contracts (StudentID, RoomID, StartDate, EndDate, MonthlyFee, Deposit, Status) VALUES
(1, 1, '2024-09-01', '2025-06-30', 500000, 500000, N'Đang hiệu lực'),
(2, 1, '2024-09-01', '2025-06-30', 500000, 500000, N'Đang hiệu lực');

-- Update Room Occupancy
UPDATE Rooms SET CurrentOccupancy = 2, Status = N'Còn chỗ' WHERE RoomID = 1;

-- Insert Invoices
INSERT INTO Invoices (ContractID, StudentID, BillingMonth, RoomFee, ElectricityFee, WaterFee, InternetFee, ServiceFee, TotalAmount, RemainingAmount, Status, DueDate) VALUES
(1, 1, '2024-10', 500000, 150000, 50000, 100000, 50000, 850000, 850000, N'Chưa thanh toán', '2024-10-05'),
(2, 2, '2024-10', 500000, 150000, 50000, 100000, 50000, 850000, 0, N'Đã thanh toán', '2024-10-05');

-- Insert Payment
INSERT INTO Payments (InvoiceID, Amount, PaymentMethod, Notes) VALUES
(2, 850000, N'Tiền mặt', N'Thanh toán đầy đủ');

-- Update Invoice after payment
UPDATE Invoices SET PaidAmount = 850000, RemainingAmount = 0, Status = N'Đã thanh toán', PaymentDate = GETDATE() WHERE InvoiceID = 2;

GO