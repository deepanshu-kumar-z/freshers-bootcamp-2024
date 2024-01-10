class ConsoleDisplayController:
    __content = ''
    def setContent(self, message):
        self.__content = message
    def display(self):
        print(self.__content)
        
class StartsWithStrategy:
    __startsWith = ''
    def setStartsWith(self, key):
        self.__startsWith = key
    def invoke(self, item):
        return item[0].lower() == self.__startsWith.lower()
        
class StringListFilterController:
    def filter(self,strList):
        for message in strList:
            startsWith = StartsWithStrategy()
            startsWith.setStartsWith('a')
            Element = ConsoleDisplayController()
            if startsWith.invoke(message):
                Element.setContent(message)
                Element.display()

arrayOfStrings = ['ayan','deep','aman']
StringListFilter = StringListFilterController()
StringListFilter.filter(arrayOfStrings)
        
