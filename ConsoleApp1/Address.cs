//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはテンプレートから生成されました。
//
//     このファイルを手動で変更すると、アプリケーションで予期しない動作が発生する可能性があります。
//     このファイルに対する手動の変更は、コードが再生成されると上書きされます。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Kana { get; set; }
        public string ZipCode { get; set; }
        public string Prefecture { get; set; }
        public string StreetAddress { get; set; }
        public string Telephone { get; set; }
        public string Mail { get; set; }
        public Nullable<int> Group_Id { get; set; }
    
        public virtual Group Group { get; set; }
    }
}
