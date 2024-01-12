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
    def __init__(self, title="DefaultTitle"):
        self.title = title
    
    def paint(self):
        print("Displaying Header titled", self.title)
 
    def save(self):
        print("Saving Header Content")
        
    def convert(self, converterClass):
        converterClass.convertHeader(self)
        pass
 
class Footer(DocumentPart):
    def __init__(self, text="DefaultText"):
        self.text = text
        
    def paint(self):
        print("Displaying Footer with text", self.text)
 
    def save(self):
        print("Saving Footer Content")
        
    def convert(self, converterClass):
        converterClass.convertFooter(self)
        pass
 
class Hyperlink(DocumentPart):
    def __init__(self, url="defaultURL.com", text="defaultText"):
        self.url = url
        self.text = text
    
    def paint(self):
        print("Displaying Hyperlink with URL {} and text {}".format(self.url, self.text))
 
    def save(self):
        print("Saving Hyperlink Content")
        
    def convert(self, converterClass):
        converterClass.convertHyperLink(self)
        pass
 
class Paragraph(DocumentPart):
    def __init__(self, content="defaultContent"):
        self.content = content
        
    def paint(self):
        print("Displaying Paragraph with content", self.content)
 
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
 
def main():
    headerObj = Header("Title1")
    hyperlinkObj = Hyperlink("google.co.in", "search")
    footerObj = Footer()
    paragraphObj = Paragraph()
    
    documentPartList = [headerObj, footerObj, hyperlinkObj, paragraphObj] 
    
    wordDoc = WordDocument(documentPartList)
    
    HTMLConverterObj = HTMLConverter()
     
    wordDoc.openDocument()
    print()
    wordDoc.saveDocument()
    print()
    print("Converting to HTML")
    print("*"*25)

    for docPart in wordDoc.documentParts:
        docPart.convert(HTMLConverterObj)
    
main()
