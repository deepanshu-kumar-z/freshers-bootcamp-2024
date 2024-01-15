from abc import ABC, abstractmethod

class DocumentPart(ABC):
    _name = ''
    _position = ''
    @abstractmethod
    def paint(self):
        pass
    @abstractmethod
    def convert(self, converterClass):
        pass
    @abstractmethod
    def save(self):
        pass
 
class Header(DocumentPart):
    def __init__(self, title="Default"):
        self.title = title
    def paint(self):
        print(self.title)
    def save(self):
        print("Saving Header Content")
    def convert(self, converterClass):
        converterClass.convertHeader(self)
        pass
 
class Footer(DocumentPart):
    def __init__(self, text="Default"):
        self.text = text
    def paint(self):
        print(self.text)
    def save(self):
        print("Saving Footer Content")
    def convert(self, converterClass):
        converterClass.convertFooter(self)
        pass
 
class Hyperlink(DocumentPart):
    def __init__(self, url="abc.com", text="default"):
        self.url = url
        self.text = text
    def paint(self):
        print(self.url, self.text)
    def save(self):
        print("Saving Hyperlink Content")
    def convert(self, converterClass):
        converterClass.convertHyperLink(self)
        pass
 
class Paragraph(DocumentPart):
    def __init__(self, content="default"):
        self.content = content
    def paint(self):
        print(self.content)
    def save(self):
        print("Saving Paragraph Content")
    def convert(self, converterClass):
        converterClass.convertPara(self)
        pass 
 
class ConverterInterface(ABC):
    @abstractmethod
    def convertHeader(self, header: Header):
        pass
    @abstractmethod
    def convertFooter(self, footer: Footer):
        pass
    @abstractmethod
    def convertHyperLink(self, hyperlink: Hyperlink):
        pass
    @abstractmethod
    def convertPara(self, paragraph: Paragraph):
        pass
    
class HTMLConverter(ConverterInterface):
    def convertHeader(self, header : Header):
        print("<h1>"+header.title+"</h1>")
    def convertFooter(self, footer : Footer):
        print("<h2>"+footer.text+"</h2>")
    def convertHyperLink(self, hyperlink : Hyperlink):
        print("<a href = {}>{}</a>".format(hyperlink.url, hyperlink.text))
    def convertPara(self, paragraph : Paragraph):
        print("<p>{}</p>".format(paragraph.content))
    
class WordDocument:
    def __init__(self, documentParts=[]):
        self.documentParts = documentParts
    def addDocumentPart(self, documentPart):
        self.documentParts.append(documentPart)
    def openDocument(self):
        for part in self.documentParts:
            part.paint()
    def saveDocument(self):
        for part in self.documentParts:
            part.save()
    def transform(self, converterObject):
        for docPart in self.documentParts:
            docPart.convert(converterObject)
            
def main():
    headerElement = Header("TITLE OF STORY")
    hyperlinkElement = Hyperlink("www.zeiss.com", "search")
    footerElement = Footer()
    paragraphElement = Paragraph("Zeiss is a wonderful organization.")
    documentPartList = [headerElement, footerElement, hyperlinkElement, paragraphElement] 
    wordDoc = WordDocument(documentPartList)
    HTMLConverterElement = HTMLConverter()
    wordDoc.openDocument()
    print()
    wordDoc.saveDocument()
    print()
    print("Converting to HTML")
    print()
    wordDoc.transform(HTMLConverterElement)
    
main()
