﻿namespace Models.Parameter
{
    public class ParameterModel : BaseModel
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public string ViewColumns { get; set; }
    }
}
