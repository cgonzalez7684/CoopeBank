USE Migracion
GO
/****** Object:  StoredProcedure dbo.proc_Registra_Paquetes    Script Date: 07/01/2016 12:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure dbo.proc_Registra_Hito 
	@IdUsuario varchar(50),
	@IdEsquema varchar(100),
	@IdTabla varchar(100),
	@TituloHito varchar(max),
	@DetalleHito varbinary(max),
	@Fecha datetime,
	@Estado int,
	@IdHito int output 
As

Begin	

	set xact_abort on
	Begin Try
		Begin Tran
		
			 Insert into Hito (IdUsuario,IdEsquema,IdTabla,TituloHito,DetalleHito,Fecha,Estado)
             values (@IdUsuario,@IdEsquema,@IdTabla,@TituloHito,@DetalleHito,@Fecha,@Estado)
			
			
		commit
			select @IdHito = @@identity
		
	End Try

	Begin catch
		Raiserror('proc_Registra_Hito. Error en el registro del Hito',11,1)
		Rollback
		
	end catch

End



