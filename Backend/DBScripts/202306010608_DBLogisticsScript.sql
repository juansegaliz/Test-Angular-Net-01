USE [Logistics]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 01/06/2023 6:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Address] [varchar](200) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
 CONSTRAINT [PK__Clients__E67E1A04EBD48771] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LandLogistics]    Script Date: 01/06/2023 6:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LandLogistics](
	[LandLogisticsID] [int] IDENTITY(1,1) NOT NULL,
	[ProductTypeID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[RegistrationDate] [date] NOT NULL,
	[DeliveryDate] [date] NOT NULL,
	[WarehouseID] [int] NOT NULL,
	[ShippingPrice] [decimal](10, 2) NOT NULL,
	[Discount] [decimal](10, 2) NOT NULL,
	[TotalPrice] [decimal](10, 2) NOT NULL,
	[VehiclePlate] [char](6) NOT NULL,
	[GuideNumber] [varchar](10) NOT NULL,
	[ClientID] [int] NOT NULL,
 CONSTRAINT [PK__LandLogi__CE56AA775E775A34] PRIMARY KEY CLUSTERED 
(
	[LandLogisticsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 01/06/2023 6:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[LoginID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[PasswordHash] [varbinary](max) NOT NULL,
	[Salt] [varbinary](16) NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[LoginID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaritimeLogistics]    Script Date: 01/06/2023 6:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaritimeLogistics](
	[MaritimeLogisticsID] [int] IDENTITY(1,1) NOT NULL,
	[ProductTypeID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[RegistrationDate] [date] NOT NULL,
	[DeliveryDate] [date] NOT NULL,
	[PortID] [int] NOT NULL,
	[ShippingPrice] [decimal](10, 2) NOT NULL,
	[Discount] [decimal](10, 2) NOT NULL,
	[TotalPrice] [decimal](10, 2) NOT NULL,
	[FleetNumber] [char](8) NOT NULL,
	[GuideNumber] [varchar](10) NOT NULL,
	[ClientID] [int] NOT NULL,
 CONSTRAINT [PK__Maritime__64F86AA366E3A816] PRIMARY KEY CLUSTERED 
(
	[MaritimeLogisticsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ports]    Script Date: 01/06/2023 6:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ports](
	[PortID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[City] [varchar](100) NOT NULL,
	[Country] [varchar](100) NOT NULL,
 CONSTRAINT [PK__Ports__D859BFAF52B24370] PRIMARY KEY CLUSTERED 
(
	[PortID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductTypes]    Script Date: 01/06/2023 6:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTypes](
	[ProductTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK__ProductT__A1312F4E1B5C689A] PRIMARY KEY CLUSTERED 
(
	[ProductTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Warehouses]    Script Date: 01/06/2023 6:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warehouses](
	[WarehouseID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Address] [varchar](200) NOT NULL,
 CONSTRAINT [PK__Warehous__2608AFD9A592B722] PRIMARY KEY CLUSTERED 
(
	[WarehouseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[LandLogistics]  WITH CHECK ADD  CONSTRAINT [FK__LandLogis__Clien__2E1BDC42] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[LandLogistics] CHECK CONSTRAINT [FK__LandLogis__Clien__2E1BDC42]
GO
ALTER TABLE [dbo].[LandLogistics]  WITH CHECK ADD  CONSTRAINT [FK__LandLogis__Produ__2C3393D0] FOREIGN KEY([ProductTypeID])
REFERENCES [dbo].[ProductTypes] ([ProductTypeID])
GO
ALTER TABLE [dbo].[LandLogistics] CHECK CONSTRAINT [FK__LandLogis__Produ__2C3393D0]
GO
ALTER TABLE [dbo].[LandLogistics]  WITH CHECK ADD  CONSTRAINT [FK__LandLogis__Wareh__2D27B809] FOREIGN KEY([WarehouseID])
REFERENCES [dbo].[Warehouses] ([WarehouseID])
GO
ALTER TABLE [dbo].[LandLogistics] CHECK CONSTRAINT [FK__LandLogis__Wareh__2D27B809]
GO
ALTER TABLE [dbo].[MaritimeLogistics]  WITH CHECK ADD  CONSTRAINT [FK__MaritimeL__Clien__32E0915F] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[MaritimeLogistics] CHECK CONSTRAINT [FK__MaritimeL__Clien__32E0915F]
GO
ALTER TABLE [dbo].[MaritimeLogistics]  WITH CHECK ADD  CONSTRAINT [FK__MaritimeL__PortI__31EC6D26] FOREIGN KEY([PortID])
REFERENCES [dbo].[Ports] ([PortID])
GO
ALTER TABLE [dbo].[MaritimeLogistics] CHECK CONSTRAINT [FK__MaritimeL__PortI__31EC6D26]
GO
ALTER TABLE [dbo].[MaritimeLogistics]  WITH CHECK ADD  CONSTRAINT [FK__MaritimeL__Produ__30F848ED] FOREIGN KEY([ProductTypeID])
REFERENCES [dbo].[ProductTypes] ([ProductTypeID])
GO
ALTER TABLE [dbo].[MaritimeLogistics] CHECK CONSTRAINT [FK__MaritimeL__Produ__30F848ED]
GO
