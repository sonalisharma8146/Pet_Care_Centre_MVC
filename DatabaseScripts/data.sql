SET IDENTITY_INSERT [dbo].[CareTaker] ON
INSERT INTO [dbo].[CareTaker] ([Id], [Name], [PhoneNumber]) VALUES (1, N'John Wilkinson', N'0213451234')
INSERT INTO [dbo].[CareTaker] ([Id], [Name], [PhoneNumber]) VALUES (2, N'Pat Davis', N'0218882345')
SET IDENTITY_INSERT [dbo].[CareTaker] OFF
SET IDENTITY_INSERT [dbo].[Pet] ON
INSERT INTO [dbo].[Pet] ([Id], [Name], [PetType]) VALUES (1, N'Milo', 0)
INSERT INTO [dbo].[Pet] ([Id], [Name], [PetType]) VALUES (2, N'LEO', 0)
INSERT INTO [dbo].[Pet] ([Id], [Name], [PetType]) VALUES (3, N'Cooper', 1)
SET IDENTITY_INSERT [dbo].[Pet] OFF
SET IDENTITY_INSERT [dbo].[PetCareSession] ON
INSERT INTO [dbo].[PetCareSession] ([Id], [CareTakerId], [PetId], [Start], [End]) VALUES (1, 1, 1, N'2020-09-12 09:06:00', N'2020-09-12 10:06:00')
INSERT INTO [dbo].[PetCareSession] ([Id], [CareTakerId], [PetId], [Start], [End]) VALUES (2, 2, 2, N'2020-09-10 09:15:00', N'2020-09-10 10:45:00')
INSERT INTO [dbo].[PetCareSession] ([Id], [CareTakerId], [PetId], [Start], [End]) VALUES (3, 1, 3, N'2020-09-11 09:45:00', N'2020-09-11 10:45:00')
SET IDENTITY_INSERT [dbo].[PetCareSession] OFF
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3efc3220-2aab-4227-a5b7-4c31e0022adf', N'admin@pets.com', N'ADMIN@PETS.COM', N'admin@pets.com', N'ADMIN@PETS.COM', 1, N'AQAAAAEAACcQAAAAEPoS/cI5vWGl8b7MszMOD5jodRdokyiDN8ywsvDBdCs65XgjckHN//qEDrTxAU96zw==', N'PWAD2PBGBYZ6BRYJDGL7MRYIYEV2NVTG', N'10a9d371-902c-4f59-af03-c7c8fa0fcc7f', NULL, 0, 0, NULL, 1, 0)

