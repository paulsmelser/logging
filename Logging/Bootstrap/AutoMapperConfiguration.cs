using System;
using System.Diagnostics.Tracing;
using System.Linq;
using AutoMapper;
using Logging.Business.Entities;
using Logging.Business.Enums;
using Logging.Business.Logic.Utilities;
using EventSource = Logging.Business.Entities.EventSource;
using Mapper = AutoMapper.Mapper;

namespace Logging.Bootstrap
{
	public class AutomapperConfiguration
	{
		public static void Configure()
		{
			Mapper.Initialize(x => x.AddProfile<BuisinessProfile>());
		}
	}

	public class BuisinessProfile : Profile
	{
		public override string ProfileName
		{
			get { return "MessageContracts"; }
		}

		protected override void Configure()
		{


			//Translations

			Mapper.CreateMap<EventWrittenEventArgs, LogEntry>()
				.ForMember(dest => dest.Keyword, opt => opt.ResolveUsing<KeywordsResolver>())
				.ForMember(dest => dest.Level, opt => opt.ResolveUsing<LevelResolver>())
				.ForMember(dest => dest.Opcode, opt => opt.ResolveUsing<OpCodesResolver>())
				.ForMember(dest => dest.Task, opt => opt.ResolveUsing<TasksResolver>())
				.ForMember(dest => dest.Payload, opt => opt.ResolveUsing<PayloadResolver>())
				.ForMember(dest => dest.Id, opt => opt.ResolveUsing<IdResolver>())
				.ForMember(dest => dest.Created, opt => opt.UseValue(DateTime.UtcNow))
				.ForMember(dest => dest.EventSource, opt => opt.MapFrom(org =>
					JsonSerializer.DeserializeObject<EventSource>(JsonSerializer.SerializeObject(org.EventSource))));

			Mapper.CreateMap<EventWrittenEventArgs, ErrorLogEntry>()
				.ForMember(dest => dest.Keyword, opt => opt.ResolveUsing<KeywordsResolver>())
				.ForMember(dest => dest.Level, opt => opt.ResolveUsing<LevelResolver>())
				.ForMember(dest => dest.Opcode, opt => opt.ResolveUsing<OpCodesResolver>())
				.ForMember(dest => dest.Task, opt => opt.ResolveUsing<TasksResolver>())
				.ForMember(dest => dest.Payload, opt => opt.ResolveUsing<ErrorPayloadResolver>())
				.ForMember(dest => dest.Id, opt => opt.ResolveUsing<IdResolver>())
				.ForMember(dest => dest.Created, opt => opt.UseValue(DateTime.UtcNow))
				.ForMember(dest => dest.ExceptionType, opt => opt.MapFrom(org => (string)org.Payload[0]))
				.ForMember(dest => dest.ExceptionMessage, opt => opt.MapFrom(org => (string)org.Payload[1]))
				.ForMember(dest => dest.StackTrace, opt => opt.MapFrom(org => (string)org.Payload[2]))
				.ForMember(dest => dest.EventSource, opt => opt.MapFrom(org =>
					JsonSerializer.DeserializeObject<EventSource>(JsonSerializer.SerializeObject(org.EventSource))));


			Mapper.AssertConfigurationIsValid();
		}

		public class OpCodesResolver : ValueResolver<EventWrittenEventArgs, Opcodes>
		{
			protected override Opcodes ResolveCore(EventWrittenEventArgs source)
			{
				return (Opcodes)source.Opcode;
			}
		}
		public class KeywordsResolver : ValueResolver<EventWrittenEventArgs, Keywords>
		{
			protected override Keywords ResolveCore(EventWrittenEventArgs source)
			{
				return (Keywords)source.Keywords;
			}
		}
		public class TasksResolver : ValueResolver<EventWrittenEventArgs, Tasks>
		{
			protected override Tasks ResolveCore(EventWrittenEventArgs source)
			{
				return (Tasks)source.Task;
			}
		}
		public class LevelResolver : ValueResolver<EventWrittenEventArgs, Levels>
		{
			protected override Levels ResolveCore(EventWrittenEventArgs source)
			{
				return (Levels)source.Level;
			}
		}

		public class PayloadResolver : ValueResolver<EventWrittenEventArgs, Payload>
		{
			protected override Payload ResolveCore(EventWrittenEventArgs source)
			{
				return new Payload(source.Payload);
			}
		}

		public class ErrorPayloadResolver : ValueResolver<EventWrittenEventArgs, Payload>
		{
			protected override Payload ResolveCore(EventWrittenEventArgs source)
			{
				return new Payload(new[] { source.Payload.Last() });

			}
		}


		public class IdResolver : ValueResolver<EventWrittenEventArgs, Guid>
		{
			protected override Guid ResolveCore(EventWrittenEventArgs source)
			{
				return Guid.NewGuid();
			}
		}

	}
}
