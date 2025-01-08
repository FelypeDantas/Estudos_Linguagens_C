@Service
public class MovieSessionService {

  private MovieSessionRepository sessionRepository;
  private UnavailabilityRepository unavailabilityRepository;
  private Converter<MovieSessionRequest, MovieSession> converter;

  public MovieSessionService(MovieSessionRepository sessionRepository, UnavailabilityRepository unavailabilityRepository, Converter<MovieSessionRequest, MovieSession> converter) {
      this.sessionRepository = sessionRepository;
      this.unavailabilityRepository = unavailabilityRepository;
      this.converter = converter;
  }

  public Result<MovieSession> createMovieSessionBy(MovieSessionRequest movieSessionRequest) {

      MovieSession newMovieSession = converter.convert(movieSessionRequest);

      Result<MovieSession> overlapResult = checkOverlapsWith(newMovieSession);

      if (overlapResult.isFail()) {
          return overlapResult;
      }

      sessionRepository.save(newMovieSession);

      return Result.success(newMovieSession);
  }

  private Result<MovieSession> checkOverlapsWith(MovieSession session) {

      if (hasOverlapsWithAnotherMovieSessionsBy(session)) {
          return Result.fail(SessionConflictException.class, session);
      }

      if (hasOverlapsWithUnavailabilitiesBy(session)) {
          return Result.fail(SessionConflictException.class, session);
      }

      return Result.success(session);
  }

  private boolean hasOverlapsWithAnotherMovieSessionsBy(MovieSession session) {
      List<MovieSession> sessions = sessionRepository.listAllByTheater(session.getTheater());

      return hasOverlapsBetween(sessions, session);

  }

  private boolean hasOverlapsWithUnavailabilitiesBy(MovieSession session) {
      List<Unavailability> unavailabilities = unavailabilityRepository.listAllByTheater(session.getTheater());

      return hasOverlapsBetween(unavailabilities, session);
  }

  private boolean hasOverlapsBetween(List<? extends Periodable> periods, MovieSession session) {
      LocalDateTime startTime = session.getStart();
      LocalDateTime endTime = session.getEnd();

      if (periods.stream().anyMatch(period -> period.getStart().equals(startTime) && period.getEnd().equals(endTime))) {
          return true;
      }

      return periods.stream().anyMatch(period -> startTime.isBefore(period.getStart()) || startTime.isAfter(period.getEnd()));
  }
}
