CREATE TABLE [Barcode] (
	[auto_id] bigint NOT NULL IDENTITY PRIMARY KEY, 
	[PRODUCT_DESC_1] nvarchar(250), 
	[BARCODE_1] nvarchar(250), 
	[MRP_1] nvarchar(250), 
	[PRODUCT_DESC_2] nvarchar(250), 
	[BARCODE_2] nvarchar(250), 
	[MRP_2] nvarchar(250)
)
GO

CREATE TABLE [ChartOfAccounts] (
	[CH_ACC_ID] bigint NOT NULL IDENTITY PRIMARY KEY, 
	[HACCID] bigint, 
	[AccountnName] nvarchar(500), 
	[OpeningBalance] float, 
	[OpeningDate] datetime, 
	[AcStatus] nvarchar(50)
)
GO

CREATE TABLE [HeadOfAccounts] (
	[HeadOfAccountsName] nvarchar(500), 
	[HACCID] bigint
)
GO

CREATE TABLE [Setting] (
	[barcode] bigint NOT NULL
)
GO

CREATE TABLE [tbl_bad_stock] (
	[stock_id] bigint NOT NULL IDENTITY PRIMARY KEY, 
	[item_id] bigint NOT NULL, 
	[User_ID] bigint NOT NULL, 
	[uom] nvarchar(50), 
	[entry_date] datetime, 
	[cost] float, 
	[reason] nvarchar(250), 
	[quantity] float
)
GO

CREATE TABLE [tbl_business] (
	[business_name] nvarchar(250), 
	[address] nvarchar(250), 
	[contact_person] nvarchar(250), 
	[telephone] nvarchar(250), 
	[fax] nvarchar(250), 
	[email] nvarchar(250), 
	[business_slogan] nvarchar(250), 
	[vat_reg_no] nvarchar(250)
)
GO

CREATE TABLE [tbl_category] (
	[category_id] bigint NOT NULL IDENTITY PRIMARY KEY, 
	[category_name] nvarchar(100)
)
GO

CREATE TABLE [tbl_customer] (
	[customer_id] bigint NOT NULL IDENTITY PRIMARY KEY, 
	[customer_name] nvarchar(250), 
	[address] nvarchar(250), 
	[phone] nvarchar(100), 
	[balance_date] datetime, 
	[status] nvarchar(10), 
	[photo] image
)
GO

CREATE TABLE [tbl_employee] (
	[emp_id] bigint NOT NULL IDENTITY PRIMARY KEY, 
	[emp_name] nvarchar(250), 
	[address] nvarchar(250), 
	[phone] nvarchar(150), 
	[join_date] datetime, 
	[special_note] nvarchar(250), 
	[status] nvarchar(10), 
	[photo] image
)
GO

CREATE TABLE [tbl_item] (
	[item_id] bigint NOT NULL IDENTITY PRIMARY KEY, 
	[supplier_id] bigint NOT NULL, 
	[item_name] nvarchar(250), 
	[barcode] nvarchar(250), 
	[quantity] float, 
	[uom] nvarchar(50), 
	[cost] float, 
	[sell_price] float, 
	[vat] float, 
	[re_order_level] float, 
	[status] nvarchar(10), 
	[category_id] bigint NOT NULL, 
	[photo] image
)
GO

CREATE TABLE [tbl_permission] (
	[User_ID] bigint NOT NULL, 
	[AccessKey] bigint NOT NULL
)
GO

CREATE TABLE [tbl_sale] (
	[SALES_ID] int NOT NULL IDENTITY PRIMARY KEY, 
	[Sales_Date] datetime, 
	[Sales_Time] nvarchar(50), 
	[User_ID] bigint NOT NULL, 
	[customer_id] bigint NOT NULL, 
	[grand_disc] float, 
	[collection_full] nvarchar(10), 
	[POS] nvarchar(10), 
	[term_of_payment] nvarchar(10), 
	[consin1] nvarchar(250), 
	[consin2] nvarchar(250), 
	[narration] nvarchar(250), 
	[Payment] float, 
	[Change] float
)
GO

CREATE TABLE [tbl_sale_details] (
	[auto_id] bigint NOT NULL IDENTITY PRIMARY KEY, 
	[SALES_ID] bigint NOT NULL, 
	[item_id] bigint NOT NULL, 
	[quantity] float, 
	[cost] float, 
	[price] float, 
	[vat] float, 
	[disc] float, 
	[total_cost] float, 
	[total_price] float, 
	[sub_total] float, 
	[retrn] nvarchar(1)
)
GO

CREATE TABLE [tbl_sale_return] (
	[RETURN_ID] bigint NOT NULL IDENTITY PRIMARY KEY, 
	[return_date] datetime, 
	[item_id] bigint NOT NULL, 
	[quantity] float, 
	[cost_total] float, 
	[SALES_ID] bigint NOT NULL, 
	[User_ID] bigint NOT NULL, 
	[customer_id] bigint NOT NULL, 
	[cost] float
)
GO

CREATE TABLE [tbl_supplier] (
	[supplier_id] bigint NOT NULL IDENTITY PRIMARY KEY, 
	[supplier_name] nvarchar(250), 
	[address] nvarchar(250), 
	[phone] nvarchar(150), 
	[balance_date] datetime, 
	[status] nvarchar(10), 
	[photo] image
)
GO

CREATE TABLE [tbl_Transaction] (
	[ID] int NOT NULL IDENTITY PRIMARY KEY, 
	[TRNS_DATE] datetime, 
	[Description] ntext, 
	[Bill_No] bigint, 
	[Receipt_No] nvarchar(50), 
	[Received] float, 
	[Paid] float, 
	[Account] ntext
)
GO

CREATE TABLE [tbl_userlog] (
	[Log_ID] bigint NOT NULL IDENTITY PRIMARY KEY, 
	[User_ID] bigint NOT NULL, 
	[Log_In] nvarchar(50), 
	[Log_Out] nvarchar(50)
)
GO

CREATE TABLE [tbl_users] (
	[User_ID] int NOT NULL IDENTITY PRIMARY KEY, 
	[user_name] nvarchar(150), 
	[password] nvarchar(250), 
	[emp_id] bigint NOT NULL, 
	[reg_date] datetime
)
GO

CREATE TABLE [tbl_usertrail] (
	[User_ID] bigint NOT NULL, 
	[Action] nvarchar(250), 
	[Date] datetime, 
	[Timex] nvarchar(50), 
	[log_ID] bigint
)
GO

CREATE TABLE [Voucher] (
	[BILL_NO] bigint NOT NULL IDENTITY PRIMARY KEY, 
	[EntryDate] datetime, 
	[CashBankID] bigint, 
	[ReceivedAcID] bigint, 
	[Description] nvarchar(500), 
	[ReceiptNo] nvarchar(500), 
	[BillType] nvarchar(50), 
	[BillCarrier] nvarchar(500), 
	[Amount] float
)
GO