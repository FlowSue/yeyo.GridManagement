using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yeyo.Infrastructure.Auth.Models;
using yeyo.Infrastructure.Treasury.Extensions;

namespace yeyo.Infrastructure.Auth.Operate
{
    internal class OperatorSetter: IEntityBaseAutoSetter
    {
        private readonly TokenModel _tokenModel;

        public OperatorSetter(IOperatorInfo operateInfo)
        {
            _tokenModel = operateInfo.TokenModel;
            TokenStr = operateInfo.TokenStr;
        }

        /// <summary>创建人姓名</summary>
        /// <value>The name of the create.</value>
        public string CreateName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_tokenModel?.RealName))
                    return StringEx.StrEmpty;
                return _tokenModel?.RealName;

            }
        }

        /// <summary>创建人Id</summary>
        /// <value>The create identifier.</value>
        public string CreateId => _tokenModel?.Uid ?? StringEx.StrEmpty;
        
        /// <summary>创建时间</summary>
        /// <value>The create time.</value>
        public DateTime CreateTime => DateTime.Now;

        /// <summary>更新人姓名</summary>
        /// <value>The name of the update.</value>
        public string UpdateName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_tokenModel?.RealName))
                    return StringEx.StrEmpty;
                return _tokenModel?.RealName;
            }
        }

        /// <summary>更新人Id</summary>
        /// <value>The update identifier.</value>
        public string UpdateId => this._tokenModel?.Uid ?? StringEx.StrEmpty;

        /// <summary>更新时间</summary>
        /// <value>The update time.</value>
        public DateTime UpdateTime => DateTime.Now;

        public string TokenStr { get; }

        public string SystemId => this._tokenModel?.SystemId;
    }
}
