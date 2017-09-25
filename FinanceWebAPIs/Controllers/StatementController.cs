using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinanceDataAccess;

namespace FinanceWebAPIs.Controllers
{
    public class StatementController : ApiController
    {
        [Route("Api/Statement/{companyId:int}")]
        public IEnumerable<IncomeStatement> Get(int companyId)
        {
            using (FinanceDataAccess.FinanceStatementEntities entities = new FinanceStatementEntities())
            {
                var templist = from a in entities.IncomeStatements
                               where a.CompanyId == companyId
                               select a;
                return templist.ToList();


            }

        }
        public IEnumerable<IncomeStatement> Get()
        {
            using (FinanceDataAccess.FinanceStatementEntities entities = new FinanceStatementEntities())
            {
                var templist = from a in entities.IncomeStatements
                               where a.CompanyId <= 15
                               select a;
                return templist.ToList();


            }

        }

    }
}
