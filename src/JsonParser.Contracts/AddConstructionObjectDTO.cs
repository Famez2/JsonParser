using Newtonsoft.Json;

namespace JsonParser.Contracts;

public class AddConstructionObjectDTO
{
    [JsonProperty("Ссылка")]
    public ReferenceInfoModel Reference { get; set; }


    [JsonProperty("Наименование")]
    public string Name { get; set; }


    [JsonProperty("ГУИД")]
    public Guid Id { get; set; }


    [JsonProperty("Сеанс")]
    public string Session { get; set; }


    [JsonProperty("Метаданные")]
    public string MetaData { get; set; }


    [JsonProperty("ТекстовыеДанные")]
    public string TextData { get; set; }


    [JsonProperty("УдалениеОбъекта")]
    public bool IsDeleted { get; set; }


    [JsonProperty("МетаКод")]
    public int MetaCode { get; set; }


    [JsonProperty("ДатаРегистрации")]
    public string DateRegistration { get; set; }


    [JsonProperty("Отправлено")]
    public bool IsPushed { get; set; }


    [JsonProperty("Обработано")]
    public bool IsProcessed { get; set; }


    [JsonProperty("ОбработкаПодтверждена")]
    public bool BeProcessedApproved { get; set; }


    [JsonProperty("ИсходящееПодтверждение")]
    public bool BeOutgoingConfirmation { get; set; }


    [JsonProperty("ВходящееПодтверждение")]
    public bool BeIncomingConfirmation { get; set; }


    [JsonProperty("ДвоичныеДанные")]
    public string BinaryData { get; set; }


    [JsonProperty("Узел")]
    public KnotInfoModel Knot { get; set; }


    [JsonProperty("ФорматСообщения")]
    public MessageFormatDto MessageFormat { get; set; }


    public class ReferenceInfoModel
    {
        [JsonProperty("Группа")]
        public string Group { get; set; }


        [JsonProperty("Имя")]
        public string Name { get; set; }


        [JsonProperty("ГУИД")]
        public Guid Id { get; set; }


        [JsonProperty("Метод")]
        public string Method { get; set; }
    }

    public class KnotInfoModel
    {
        [JsonProperty("Ссылка")]
        public ReferenceInfoModel Reference { get; set; }


        [JsonProperty("Код")]
        public string Code { get; set; }
    }

    public class MessageFormatDto
    {
        [JsonProperty("Группа")]
        public string Group { get; set; }


        [JsonProperty("Имя")]
        public string Name { get; set; }


        [JsonProperty("Значение")]
        public string Value { get; set; }
    }
}
