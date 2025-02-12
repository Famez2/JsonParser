namespace JsonParser.Contracts;

public class GetConstructionObjectsDTO
{
    public List<ConstructionObjectInfoModel> ConstructionObjects { get; set; }

    public class ConstructionObjectInfoModel
    {
        public string Name { get; set; }

        public Guid Id { get; set; }

        public string Session { get; set; }

        public string MetaData { get; set; }

        public string TextData { get; set; }

        public bool IsDeleted { get; set; }

        public int MetaCode { get; set; }

        public string DateRegistration { get; set; }

        public bool IsPushed { get; set; }

        public bool IsProcessed { get; set; }

        public bool BeProcessedApproved { get; set; }

        public bool BeOutgoingConfirmation { get; set; }

        public bool BeIncomingConfirmation { get; set; }

        public string BinaryData { get; set; }

        public List<KnotInfoModel> Knotes { get; set; } = [];

        public List<MessageFormatInfoModel> MessageFormates { get; set; } = [];

        public List<ReferenceInfoModel> References { get; set; } = [];

        public string KnotesString => string.Join(", ", Knotes.Select(k => k.Code));

        public string MessageFormatsString => string.Join(", ", MessageFormates.Select(m => m.Name));

        public string ReferencesString => string.Join(", ", References.Select(r => r.Name));

        public class ReferenceInfoModel
        {
            public string Group { get; set; }


            public string Name { get; set; }


            public Guid Id { get; set; }


            public string Method { get; set; }
        }

        public class KnotInfoModel
        {
            public ReferenceInfoModel Reference { get; set; }


            public string Code { get; set; }
        }

        public class MessageFormatInfoModel
        {
            public string Group { get; set; }


            public string Name { get; set; }


            public string Value { get; set; }
        }
    }
}
