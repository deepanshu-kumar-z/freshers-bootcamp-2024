from abc import ABC, abstractmethod

class IEngine(ABC):
    @abstractmethod
    def set_engine(self, engine_name):
        pass

    @abstractmethod
    def get_engine(self):
        pass

class IFuelPump(ABC):
    @abstractmethod
    def pump_fuel(self):
        pass

class IStartUpMotor(ABC):
    @abstractmethod
    def start_up(self):
        pass

class ITransmission(ABC):
    @abstractmethod
    def transmit(self):
        pass

class ICar(ABC):
    @abstractmethod
    def get_details(self):
        pass

class FuelPump(IFuelPump):
    def pump_fuel(self):
        pass

class StartUpMotor(IStartUpMotor):
    def start_up(self):
        pass

class Transmission(ITransmission):
    def transmit(self):
        pass

class Engine(IEngine):
    def __init__(self, fuel_pump, start_up_motor):
        self.fuel_pump = fuel_pump
        self.start_up_motor = start_up_motor

    def set_engine(self, engine_name):
        pass

    def get_engine(self):
        pass

    def get_details(self):
        return [self.fuel_pump, self.start_up_motor]

class Car(ICar, Engine, Transmission):
    def __init__(self, engine, transmission):
        super().__init__(engine.fuel_pump, engine.start_up_motor)
        self.engine = engine
        self.transmission = transmission

    def get_details(self):
        engine_details = super().get_details() or []
        return [*engine_details, self.transmission]

class DIContainer:
    @staticmethod
    def create_engine():
        fuel_pump = FuelPump()
        start_up_motor = StartUpMotor()
        return Engine(fuel_pump, start_up_motor)

    @staticmethod
    def create_transmission():
        return Transmission()

    @staticmethod
    def create_car():
        engine = DIContainer.create_engine()
        transmission = DIContainer.create_transmission()
        return Car(engine, transmission)

car = DIContainer.create_car()
details = car.get_details()
print(details)
