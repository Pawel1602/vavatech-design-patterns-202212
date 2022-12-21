using System;
using System.Collections.Generic;
using System.Text;

namespace MementoPattern.Problem
{
    // Originator (inicjator)
    public class Article
    {
        public string Content { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // Backup
        public ArticleMemento CreateMemento() => new ArticleMemento(Content, Title);
        
        // Restore
        public void SetMemento(ArticleMemento memento)
        {
            this.Title = memento.Title;
            this.Content = memento.Content;
        }

        public override string ToString() => $"{Title} {Content}";
    }

    // Memento (migawka)
    public class ArticleMemento
    {
        public string Content { get; set; }
        public string Title { get; set; }
        public DateTime SnapshotDate { get; set; }

        public ArticleMemento(string content, string title)
        {
            Content = content;
            Title = title;
            SnapshotDate = DateTime.Now;
        }

        public override string ToString() => $"[{SnapshotDate}] {Title} {Content}";
    }

    // Abstract Caretaker
    public interface IArticleCaretaker
    {
        void SetState(ArticleMemento memento);
        ArticleMemento GetState();
        IEnumerable<ArticleMemento> History { get; }
    }

    // Concrete Caretaker
    // odpowiedzialny za przechowywanie i pobieranie migawki
    public class LastArticleCaretaker : IArticleCaretaker
    {
        private ArticleMemento memento;

        public IEnumerable<ArticleMemento> History => new List<ArticleMemento> { memento };

        public void SetState(ArticleMemento memento)
        {
            this.memento = memento;
        }

        public ArticleMemento GetState()
        {
            return this.memento;
        }        
    }

    // Concrete Caretaker
    public class StackArticleCaretaker : IArticleCaretaker
    {
        private Stack<ArticleMemento> mementos = new Stack<ArticleMemento>();
        public IEnumerable<ArticleMemento> History => mementos;
        public ArticleMemento GetState() => mementos.Pop();
        public void SetState(ArticleMemento memento) => mementos.Push(memento);
    }
}
