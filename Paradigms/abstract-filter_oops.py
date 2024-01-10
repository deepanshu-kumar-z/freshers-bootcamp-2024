from abc import ABC, abstractmethod

class DisplayController(ABC):
    @abstractmethod
    def set_content(self, message):
        pass
    
    @abstractmethod
    def display(self):
        pass


class ConsoleDisplayController(DisplayController):
    def __init__(self):
        self.__content = ''

    def set_content(self, message):
        self.__content = message

    def display(self):
        print(self.__content)


class SearchStrategy(ABC):
    @abstractmethod
    def invoke(self, item):
        pass


class StartsWithStrategy(SearchStrategy):
    def __init__(self):
        self.__starts_with = ''

    def set_starts_with(self, key):
        self.__starts_with = key

    def invoke(self, item):
        return item[0].lower() == self.__starts_with.lower()


class StringListFilterController:
    def __init__(self, strategy):
        self.__strategy = strategy

    def filter(self, str_list):
        for message in str_list:
            if self.__strategy.invoke(message):
                element = ConsoleDisplayController()
                element.set_content(message)
                element.display()


array_of_strings = ['ayan', 'deep', 'aman']
starts_with_strategy = StartsWithStrategy()
starts_with_strategy.set_starts_with('a')
string_list_filter = StringListFilterController(starts_with_strategy)
string_list_filter.filter(array_of_strings)
