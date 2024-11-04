class Socio:
    socios = []
    def __init__ (self, idSocio, nombreSocio, email, celular):
        self.idSocio = idSocio
        self.nombreSocio = nombreSocio
        self.email = email
        self.celular = celular
        Socio.socios.append(self) #Agregar socio a la lista
    
    def crear_Socio(self):
        pass

    def consultar_Socio(self):
        return f"ID: {self.idSocio}, Nombre: {self.nombreSocio}, Email: {self.email}, Celular: {self.celular}"
    
    @classmethod  #Método que no requiere la instancia
    def listar_socios(cls):
        if not cls.socios:
           print ('No hay socios disponibles')
           return 
        for socio in cls.socios:
            print(f"ID: {socio.idSocio}, Nombre: {socio.nombreSocio}, Email: {socio.email}, Celular: {socio.celular}")
     

# socio1 = Socio(1,"Lina Gomez", "linag@gmail.com", "3125666352")
# socio2 = Socio(2,"Juan Hernandez", "juanh67@gmail.com", "3215688355")

# Socio.listar_socios()

#Subclase fundadores
class SFundadores(Socio):
    def __init__(self, idSocio, nombreSocio, email, celular, fecha_ingreso):
        super().__init__(idSocio, nombreSocio, email, celular)
        self.fecha_ingreso = fecha_ingreso

    def actualizar_fecha(self, nueva_fecha):
        self.fecha_ingreso = nueva_fecha
        return f"Fecha de ingreso actualizada a: {self.fecha_ingreso}"

class SDeportista(Socio):
    def __init__(self, idSocio, nombreSocio, email, celular, deporte):
        super().__init__(idSocio, nombreSocio, email, celular)
        self.deporte = deporte

    def actualizar_deporte(self, nuevo_deporte):
        self.deporte = nuevo_deporte
        return f"Deporte actualizado a: {self.deporte}"

class SFamiliar(Socio):
    def __init__(self, idSocio, nombreSocio, email, celular, nomFamiliar):
        super().__init__(idSocio, nombreSocio, email, celular)
        self.nomFamiliar = nomFamiliar

    def actualizar_nomFamiliar(self, nuevo_Familiar):
        self.nomFamiliar = nuevo_Familiar
        return f"Nombre de familiar actualizado a: {self.deporte}"
    

if __name__ == "__main__":
    #Crear diferentes socios
    socio1 = Socio(3,"Johana Yepes", "johayepes", "3124558952")
    fundador = SFundadores(7,"Ismael Rodriguez","ismael@gmail.com","3215564411","2020-01-05")
    deportista = SDeportista(7,"Ivan Betancur","ivanb@hotmail.com","3225111111","Tenis")
    familiar = SFamiliar(7,"Silvia Ramirez","silvia@hotmail.com","3145454541","Gabriel Perez")

    Socio.listar_socios()

    #Consultar socio familiar
    print (f"Nombre de familiar: ",{familiar.consultar_Socio()})

    #Actualizar datos de socio deportista
    print(deportista.actualizar_deporte("Natación"))