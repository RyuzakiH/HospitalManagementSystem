USE [Hospital]
GO


INSERT INTO [dbo].[Doctors] ([Id], [Name]) VALUES (0, 'Andrew')
INSERT INTO [dbo].[Doctors] ([Id], [Name]) VALUES (1, 'Tarek')
INSERT INTO [dbo].[Doctors] ([Id], [Name]) VALUES (2, 'Mohamed')
GO


INSERT INTO [dbo].[Nurses] ([Id], [Name]) VALUES (0, 'Joseph')
INSERT INTO [dbo].[Nurses] ([Id], [Name]) VALUES (1, 'Fawziya')
INSERT INTO [dbo].[Nurses] ([Id], [Name]) VALUES (2, 'Sophie')
GO


INSERT INTO [dbo].[Rooms] ([Id], [Type]) VALUES (0, 'ICU')
INSERT INTO [dbo].[Rooms] ([Id], [Type]) VALUES (1, 'Theatre')
INSERT INTO [dbo].[Rooms] ([Id], [Type]) VALUES (2, 'Normal')
GO



INSERT INTO [dbo].[Patients]
           ([Id], [Name], [Mobile], [Address], [Gender], [Disease],
		   [Admitted], [DateAdmitted], [DateDischarged], [Bill], [DoctorId], [NurseId], [RoomId])
     VALUES (0, 'Hazem', '+201156257345', '46 Abd El-Rahman Soliman st.', 'male', 'Bipolar Disorder',0, NULL, NULL, NULL, 0, 0, 0)

INSERT INTO [dbo].[Patients]
           ([Id], [Name], [Mobile], [Address], [Gender], [Disease],
		   [Admitted], [DateAdmitted], [DateDischarged], [Bill], [DoctorId], [NurseId], [RoomId])
     VALUES (1, 'Abdallah', '+2018XX2579X5', '25 El-Galaa st., Tanta', 'male', 'Broken Arm',0, NULL, NULL, NULL, 1, 1, 1)

INSERT INTO [dbo].[Patients]
           ([Id], [Name], [Mobile], [Address], [Gender], [Disease],
		   [Admitted], [DateAdmitted], [DateDischarged], [Bill], [DoctorId], [NurseId], [RoomId])
     VALUES (2, 'Ryuzaki', '+2012XXXXXXXX', 'Kafr El-Zayat', 'male', 'Bipolar Disorder',0, NULL, NULL, NULL, 2, 2, 2)
GO




INSERT INTO [dbo].[Users] ([UserId], [Username], [Password], [Role], [PrivateId]) VALUES (0, 'admin', 'admin', 'admin', 0)
INSERT INTO [dbo].[Users] ([UserId], [Username], [Password], [Role], [PrivateId]) VALUES (1, 'andrew', 'pass', 'doctor', 0)
INSERT INTO [dbo].[Users] ([UserId], [Username], [Password], [Role], [PrivateId]) VALUES (2, 'hazem', 'password', 'patient', 0)
INSERT INTO [dbo].[Users] ([UserId], [Username], [Password], [Role], [PrivateId]) VALUES (3, 'joseph', 'p4ss', 'nurse', 0)
GO

