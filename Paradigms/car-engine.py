class Car:
    def __init__(self,engineObj, transmissionObj):
        self.engine = engineObj
        self.transmission = transmissionObj
    def getDetails(self):
        return [self.engine, self.transmission]
        
class ITransmission(ABC):
    @abstractmethod
    def setTransmission(self,transmissionName):
        pass
    @abstractmethod
    def getTransmission(self):
        pass
    
class Transmission(ITransmission):
    def setTransmission(self,transmissionName):
        self.transmission = transmissionName

    def getTransmission(self):
        return self.transmissionName

class IEngine(ABC):
    @abstractmethod
    def setEngine(self,engineName):
        pass
    @abstractmethod
    def getEngine(self):
        pass

class Engine:
    def __init__(self, FuelPumpObj, StartupMotorObj):
        self.fuelPump = FuelPumpObj
        self.startUpMotor = StartupMotorObj
    def getDetails(self):
        return [self.fuelPump, self.startUpMotor]
        
    def setEngine(self,engineName):
        self.engine = engineName
        
    def getEngine(self):
        return self.engineName
        
class IFuelPump(ABC):
    @abstractmethod
    def setFuelPump(self,fuelPumpName):
        pass
    @abstractmethod
    def getFuelPump(self):
        pass
 
class FuelPump(IFuelPump):
    def setFuelPump(self,fuelPumpName):
        self.fuelPump = fuelPumpName
    def getFuelPump(self):
        return self.fuelPump

class IStartUpMotor(ABC):
    @abstractmethod
    def setStartUpMotor(self,startUpMotorName):
        pass
    @abstractmethod
    def getStartUpMotor(self):
        pass
 
class StartUpMotor(IStartUpMotor):
    def setStartUpMotor(self,startUpMotorName):
        self.startUpMotor = startUpMotorName
    def getStartUpMotor(self):
        pass
