using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using searchingLibrary;

// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Реструктуризация" можно использовать для одновременного изменения имени класса "Service" в коде, SVC-файле и файле конфигурации.
public class Service : IService
{
	public Dictionary<string, int> GetText (string fileText)
	{
        cleverSearchClass search = new cleverSearchClass();
        Dictionary<string, int> result = search.PublicAnalyser(fileText);
        return result;
	}

}
