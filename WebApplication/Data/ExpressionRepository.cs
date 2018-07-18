using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Data
{
    public class ExpressionRepository : BaseRepository<MathExpression>, IExpressionRepository
    {
        public ExpressionRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
    public interface IExpressionRepository : IRepository<MathExpression>
    {

    }
}