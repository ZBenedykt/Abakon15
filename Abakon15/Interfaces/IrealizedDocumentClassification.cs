using System.Collections.Generic;
using AbakonDataModel;

namespace Abakon15.Interfaces
{
    public interface IrealizedDocumentClassification<T>
    {
        string Name { get; }
        int realizedId { get; }
        int? realizedParentId { get; }
        int documentClassificationId { get; }
        bool isFolder { get; }
        bool hasDocuments { get; }
        string ClassificationPath { get; }
        DocumentClassifierForEntitiesEnum DocumentClassifierForEntities { get; }
        T GetNodeForDocumentClassificationPattern(int documentClassificationId);
        ICollection<T> realizedChildren { get; }
    }

    public interface IEntityWithDocuments<T, R> where R : IrealizedDocumentClassification<R>
    {
        DocumentClassifierForEntitiesEnum forEntity { get; } //potrzebne do identyfikacji klasyfikatorów przeznaczonych dla danej encji
        ICollection<IrealizedDocumentClassification<R>> realizedChildren { get; }  //zrealizowane drzewo
    }
}


