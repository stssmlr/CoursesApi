using Ardalis.Specification;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Entities.Specifications
{
    public static class AuthorSpecification
    {
        public class All : Specification<Author>
        {
            public All()
            {
                Query.Include(x => x.Id);
            }
        }

        public class ByEmail : Specification<Author>
        {
            public ByEmail(string email)
            {
                Query.Where(c => c.Email == email);
            }
        }
    }
}
