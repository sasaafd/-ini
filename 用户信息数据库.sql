USE [用户信息数据库]
GO
/****** Object:  Table [dbo].[text]    Script Date: 2022/6/9 11:35:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[text](
	[手机号] [nchar](11) NOT NULL,
	[用户名] [nchar](10) NULL,
	[密码] [nchar](20) NULL,
 CONSTRAINT [PK_text] PRIMARY KEY CLUSTERED 
(
	[手机号] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[text1]    Script Date: 2022/6/9 11:35:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[text1](
	[商家手机号] [nchar](11) NOT NULL,
	[商家密码] [nchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[text3]    Script Date: 2022/6/9 11:35:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[text3](
	[商品编号] [int] NOT NULL,
	[商品名称] [varchar](50) NULL,
	[商品价格] [float] NULL,
 CONSTRAINT [PK_text3] PRIMARY KEY CLUSTERED 
(
	[商品编号] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[text4]    Script Date: 2022/6/9 11:35:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[text4](
	[商品名称] [nchar](100) NOT NULL,
	[商品价格] [nchar](100) NULL,
	[合计] [nchar](100) NULL,
	[手机号] [nchar](11) NULL,
	[地址] [nchar](30) NULL,
	[购买时间] [nchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[text] ([手机号], [用户名], [密码]) VALUES (N'1          ', N'阿龙        ', N'1                   ')
INSERT [dbo].[text] ([手机号], [用户名], [密码]) VALUES (N'1234567    ', N'1         ', N'1234567             ')
INSERT [dbo].[text] ([手机号], [用户名], [密码]) VALUES (N'12345678901', N'张三        ', N'123456              ')
INSERT [dbo].[text] ([手机号], [用户名], [密码]) VALUES (N'12345678910', N'张杰        ', N'123456              ')
INSERT [dbo].[text] ([手机号], [用户名], [密码]) VALUES (N'12345678998', N'啊啊啊       ', N'123456              ')
INSERT [dbo].[text] ([手机号], [用户名], [密码]) VALUES (N'12345678999', N'李四        ', N'123456              ')
INSERT [dbo].[text] ([手机号], [用户名], [密码]) VALUES (N'13020505050', N'张望        ', N'123456              ')
INSERT [dbo].[text] ([手机号], [用户名], [密码]) VALUES (N'13020505080', N'张威        ', N'123456              ')
INSERT [dbo].[text] ([手机号], [用户名], [密码]) VALUES (N'13020505081', N'刘国庆       ', N'123456              ')
INSERT [dbo].[text] ([手机号], [用户名], [密码]) VALUES (N'13020505088', N'张三        ', N'123456              ')
INSERT [dbo].[text] ([手机号], [用户名], [密码]) VALUES (N'14465657788', N'王俊凯       ', N'666666              ')
INSERT [dbo].[text] ([手机号], [用户名], [密码]) VALUES (N'15463483359', N'易烊千玺      ', N'212121              ')
INSERT [dbo].[text] ([手机号], [用户名], [密码]) VALUES (N'15903471345', N'沈腾        ', N'778899              ')
INSERT [dbo].[text] ([手机号], [用户名], [密码]) VALUES (N'16434562222', N'宋小宝       ', N'233333              ')
INSERT [dbo].[text] ([手机号], [用户名], [密码]) VALUES (N'17735686874', N'贾玲        ', N'000000              ')
INSERT [dbo].[text] ([手机号], [用户名], [密码]) VALUES (N'18854185008', N'老师        ', N'123456              ')
INSERT [dbo].[text] ([手机号], [用户名], [密码]) VALUES (N'18946586947', N'谢娜        ', N'654321              ')
INSERT [dbo].[text] ([手机号], [用户名], [密码]) VALUES (N'19963544488', N' 王源       ', N'111111              ')
INSERT [dbo].[text] ([手机号], [用户名], [密码]) VALUES (N'23         ', N'23        ', N'23                  ')
INSERT [dbo].[text] ([手机号], [用户名], [密码]) VALUES (N'33         ', N'33        ', N'33                  ')
GO
INSERT [dbo].[text1] ([商家手机号], [商家密码]) VALUES (N'13020505081', N'123456              ')
INSERT [dbo].[text1] ([商家手机号], [商家密码]) VALUES (N'2          ', N'2                   ')
GO
INSERT [dbo].[text3] ([商品编号], [商品名称], [商品价格]) VALUES (3, N'麻辣烫                 ', 15)
INSERT [dbo].[text3] ([商品编号], [商品名称], [商品价格]) VALUES (8, N'彩虹饭+鲜汤', 8)
INSERT [dbo].[text3] ([商品编号], [商品名称], [商品价格]) VALUES (9, N'砂锅金汤鸭', 10)
INSERT [dbo].[text3] ([商品编号], [商品名称], [商品价格]) VALUES (10, N'砂锅金汤蟹', 11)
INSERT [dbo].[text3] ([商品编号], [商品名称], [商品价格]) VALUES (11, N'砂锅金汤鸡肉丸', 11)
INSERT [dbo].[text3] ([商品编号], [商品名称], [商品价格]) VALUES (12, N'砂锅金汤肥牛', 14)
INSERT [dbo].[text3] ([商品编号], [商品名称], [商品价格]) VALUES (13, N'馋嘴鱼', 14)
INSERT [dbo].[text3] ([商品编号], [商品名称], [商品价格]) VALUES (14, N'馋嘴鸡', 13)
INSERT [dbo].[text3] ([商品编号], [商品名称], [商品价格]) VALUES (15, N'鸡公煲', 15)
INSERT [dbo].[text3] ([商品编号], [商品名称], [商品价格]) VALUES (16, N'烤盘饭', 9.9)
INSERT [dbo].[text3] ([商品编号], [商品名称], [商品价格]) VALUES (19, N'靠龙肉', 100)
INSERT [dbo].[text3] ([商品编号], [商品名称], [商品价格]) VALUES (20, N'烤乳猪', 30)
INSERT [dbo].[text3] ([商品编号], [商品名称], [商品价格]) VALUES (21, N'烤地瓜', 9)
INSERT [dbo].[text3] ([商品编号], [商品名称], [商品价格]) VALUES (22, N'烤面筋', 11)
INSERT [dbo].[text3] ([商品编号], [商品名称], [商品价格]) VALUES (23, N'沙拉', 13)
GO
INSERT [dbo].[text4] ([商品名称], [商品价格], [合计], [手机号], [地址], [购买时间]) VALUES (N'馋嘴鱼,砂锅金汤鸭,砂锅金汤肥牛,                                                                                   ', N'14,10,14,                                                                                           ', N'38                                                                                                  ', N'123213131  ', N'舒舒服服                          ', N'15:12:17                                          ')
GO
