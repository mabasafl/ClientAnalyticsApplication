namespace Application.Core.Interfaces
{
    public interface IMapper<TModel,TDto>
    {
        TDto Map(TModel model); 
        TModel Map(TDto dto);
    }
}
