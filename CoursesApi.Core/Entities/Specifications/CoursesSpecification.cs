using Ardalis.Specification;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Entities.Specifications
{
    public class CoursesSpecification 
    {
        public class All : Specification<Courses>
        {
            public All()
            {
                Query.Include(x => x.Category);
            }
        }

        public class ByCategory : Specification<Courses>
        {
            public ByCategory(int categoryId)
            {
                Query.Include(x => x.Category)
                    .Where(c => c.CategoryId == categoryId);
            }
        }

        public class ByAuthor : Specification<Courses>
        {
            public ByAuthor(int authorId)
            {
                Query.Include(x => x.Author)
                    .Where(c => c.AuthorId == authorId);
            }
        }
    }
}
