SET IDENTITY_INSERT [dbo].[Customer] ON
INSERT INTO [dbo].[Customer] ([Id], [Name], [EmailAddress], [Mobile]) VALUES (1, N'Garry Smith', N'garry@gmail.com', N'02133300087')
INSERT INTO [dbo].[Customer] ([Id], [Name], [EmailAddress], [Mobile]) VALUES (2, N'Adam Bell', N'adam@gmail.com', N'021888654')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[DeliveryAgent] ON
INSERT INTO [dbo].[DeliveryAgent] ([Id], [Name], [Mobile]) VALUES (1, N'James Anderson', N'0218886543')
INSERT INTO [dbo].[DeliveryAgent] ([Id], [Name], [Mobile]) VALUES (2, N'Ray Harrison ', N'0218886543')
SET IDENTITY_INSERT [dbo].[DeliveryAgent] OFF
SET IDENTITY_INSERT [dbo].[LunchPack] ON
INSERT INTO [dbo].[LunchPack] ([Id], [Description], [Price]) VALUES (1, N'Regular Lunch Pack', CAST(6.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[LunchPack] ([Id], [Description], [Price]) VALUES (2, N'Large Pack -With Dessert', CAST(12.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[LunchPack] ([Id], [Description], [Price]) VALUES (3, N'Large Pack', CAST(8.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[LunchPack] OFF
SET IDENTITY_INSERT [dbo].[OnlineDelivery] ON
INSERT INTO [dbo].[OnlineDelivery] ([Id], [DeliveryAgentId], [LunchPackId], [CustomerId], [NumberOfPacks], [Address]) VALUES (1, 1, 1, 1, 5, NULL)
INSERT INTO [dbo].[OnlineDelivery] ([Id], [DeliveryAgentId], [LunchPackId], [CustomerId], [NumberOfPacks], [Address]) VALUES (2, 2, 2, 2, 10, NULL)
SET IDENTITY_INSERT [dbo].[OnlineDelivery] OFF
