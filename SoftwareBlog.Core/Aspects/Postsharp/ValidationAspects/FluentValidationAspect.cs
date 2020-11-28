using System;
using System.Linq;
using FluentValidation;
using PostSharp.Aspects;
using SoftwareBlog.Core.CrossCuttingConcerns.Validation.FluentValidation;

namespace SoftwareBlog.Core.Aspects.Postsharp.ValidationAspects
{
    [Serializable]
     public class FluentValidationAspect:OnMethodBoundaryAspect
     {
        Type _validatorType;                      // neyle valide edeceğim bilgisi

        public FluentValidationAspect(Type validatorType)//productvalidor,categoryvalidator...gibi
        {
            _validatorType = validatorType;
        }
        public override void OnEntry(MethodExecutionArgs args)// methoda girildiğinde doğrulama yapmak istiyoruz.
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //neyle validate edeceksem onun                                                                             instancenı oluşturuyorum(bana                                                                            birtane validator oluşturacak)

            var entityType = _validatorType.BaseType.GetGenericArguments()[0];   //çalışacağım nesne tipinin ne                                                                             olduğunu 
                                                                                 //_validatorType.BaseType ın (kimdi                                                          AbstactValidator) generic                                                              argümanlarına bak 1 tane döndürür(1.                                            generiği) onu   al : artık burda ben product                                                      nesnesi ile çalışacağımı biliyorum
                                                                                   

            var entities = args.Arguments.Where(t => t.GetType() == entityType);
                                                                  //çalışacağım methodun içindeki productı arıyorum
                                                                  //örneğin add metodunun
                                                                  //t için tüm arg gez veri tipini al ve o tip entytype                                    eşitse onu entities e ekle 
            foreach (var entity in entities)   
            {
               ValidatorTool.FluentValidate(validator,entity);     //foreacle geziyoruz bunları entities i gez
                                                                   //validator=ProductValidator
                                                                   //entity =parametre ile gelen entity
            }
        }
    }
}
